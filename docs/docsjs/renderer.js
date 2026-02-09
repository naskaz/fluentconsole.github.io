/**
 * Dynamic Documentation Renderer for GitHub Pages
 * - Loads feature manifests & examples via hash routing
 * - Uses Prism.js for syntax highlighting
 * - No hardcoded filenames — uses manifest.json metadata
 */

(() => {
  'use strict';

  let selectEl, loaderEl, errorEl, codeEl, preEl;
  let currentFeature = null;
  let currentExample = null;
  let examplesList = []; // Will store { folder, file }

  const FEATURES_BASE = '../features';

  function init() {
    if (document.readyState === 'loading') {
      document.addEventListener('DOMContentLoaded', setup);
    } else {
      setup();
    }
  }

  function setup() {
    window.addEventListener('hashchange', handleHashChange);
    handleHashChange();
  }

  function handleHashChange() {
    const hash = window.location.hash.substring(1);
    if (!hash) return;

    const validFeatures = ['number', 'datetime', 'naturalstring', 'plainstring', 'ipaddress', 'percentage', 'filesize', 'version', 'currency'];
    if (!validFeatures.includes(hash)) return;

    loadFeature(hash);
  }

  async function loadFeature(featureName) {

    if (featureName === currentFeature) return;

    resetUI();
    currentFeature = featureName;
    currentExample = null;
    examplesList = [];

    const container = document.querySelector(
      `[data-feature="${featureName}"]`
    );
    if (!container) {
      console.warn('[renderer] No [data-feature-section] found');
      return;
    }

    selectEl = container.querySelector('.example-select');
    loaderEl = container.querySelector('.example-loader');
    errorEl = container.querySelector('.example-error');
    codeEl = container.querySelector('.example-code');
    preEl = container.querySelector('pre.line-numbers');


    try {
      showLoader();

      const manifestUrl = `${FEATURES_BASE}/${featureName}/manifest.json`;
      const manifestResp = await fetch(manifestUrl);


      if (!manifestResp.ok) {
        const text = await manifestResp.text().catch(() => '—');
        throw new Error(`Manifest fetch failed: ${manifestResp.status} ${manifestResp.statusText}\nResponse: ${text}`);
      }

      const manifest = await manifestResp.json();

      examplesList = manifest.examples
        .map(ex => ({ folder: ex.folder, file: ex.file || 'demo.cs' }))
        .filter(ex => ex.folder);

      if (examplesList.length === 0) throw new Error('No examples in manifest');

      renderExampleSelector();
      await loadExample(examplesList[0]);

    } catch (err) {
      console.error('[renderer] CRITICAL ERROR:', err);
      showError(`Failed to load feature "${featureName}": ${err.message}`);
    } finally {
      hideLoader();
    }
  }


  function renderExampleSelector() {
    if (!selectEl || examplesList.length === 0) return;

    selectEl.innerHTML = '';
    examplesList.forEach(ex => {
      const option = document.createElement('option');
      option.value = ex.folder;
      const displayName = ex.folder.replace(/^example(\d+)$/, 'Example $1') || ex.folder;
      option.textContent = displayName;
      selectEl.appendChild(option);
    });

    selectEl.disabled = false;
    selectEl.addEventListener('change', handleExampleSelect);
  }

  async function handleExampleSelect(event) {
    const folder = event.target.value;
    const example = examplesList.find(ex => ex.folder === folder);
    if (!example || example.folder === currentExample) return;
    await loadExample(example);
  }


  async function loadExample(example) {
    if (!currentFeature || !example) return;

    try {
      showLoader();
      hideError();

      const { folder, file } = example;
      const codeUrl = `${FEATURES_BASE}/${currentFeature}/${folder}/${file}`;

      const codeResp = await fetch(codeUrl);
      if (!codeResp.ok) throw new Error(`HTTP ${codeResp.status}: ${file}`);

      let codeText = await codeResp.text();
      if (!codeText.trim()) throw new Error('Empty code file');

      // ✅ MOBILE WRAP FIX: Insert zero-width space after commas inside "strings"
      if (window.innerWidth < 768) {
        codeText = codeText.replace(/("([^"\\]|\\.)*")/g, (match) =>
          match.replace(/,/g, ',\u200B')
        );
      }

      codeEl.textContent = codeText;
      preEl.classList.remove('d-none');

      if (typeof Prism !== 'undefined') {
        Prism.highlightElement(codeEl);
      }

      const copyBtn = codeEl.closest('.feature-examples')?.querySelector('.copy-code-btn');
      if (copyBtn) {
        const oldListener = copyBtn._clickListener;
        if (oldListener) copyBtn.removeEventListener('click', oldListener);

        const newListener = () => {
          navigator.clipboard.writeText(codeText).then(() => {
            const originalIcon = copyBtn.innerHTML;
            copyBtn.innerHTML = '<i class="fa-solid fa-check"></i>';
            copyBtn.classList.replace('btn-outline-secondary', 'btn-success');
            setTimeout(() => {
              copyBtn.innerHTML = originalIcon;
              copyBtn.classList.replace('btn-success', 'btn-outline-secondary');
            }, 2000);
          }).catch(err => {
            console.error('Copy failed:', err);
          });
        };

        copyBtn.addEventListener('click', newListener);
        copyBtn._clickListener = newListener;
      }

      currentExample = folder;

    } catch (err) {
      showError(`Failed to load example: ${err.message}`);
      console.error('Example load error:', err);
      preEl.classList.add('d-none');
    } finally {
      hideLoader();
    }
  }

  function showLoader() {
    if (loaderEl) loaderEl.classList.remove('d-none');
  }

  function hideLoader() {
    if (loaderEl) loaderEl.classList.add('d-none');
  }

  function showError(message) {
    if (errorEl) {
      errorEl.textContent = message;
      errorEl.classList.remove('d-none');
    }
  }

  function hideError() {
    if (errorEl) errorEl.classList.add('d-none');
  }

  function resetUI() {
    if (selectEl) {
      selectEl.innerHTML = '<option>Loading examples...</option>';
      selectEl.disabled = true;
      selectEl.removeEventListener('change', handleExampleSelect);
    }
    if (preEl) preEl.classList.add('d-none');
    hideError();
  }

  window.reloadFeatureExamples = () => {
    const hash = window.location.hash.substring(1);
    const validFeatures = ['number', 'datetime', 'naturalstring', 'plainstring', 'ipaddress', 'percentage', 'filesize', 'version', 'currency'];
    if (validFeatures.includes(hash)) {
      // Reset state to force reload
      currentFeature = null;
      handleHashChange();
    }
  };

  init();
})();

