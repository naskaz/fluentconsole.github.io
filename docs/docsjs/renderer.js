// js/renderer.js - DYNAMIC VARIATION SUPPORT (uses manifest keys directly)
(() => {
  "use strict";

  const manifestCache = new Map();
  const codeCache = new Map();

  // ============================================
  // LOAD MANIFEST
  // ============================================
  async function loadManifest(feature) {
    if (manifestCache.has(feature)) {
      return manifestCache.get(feature);
    }
    
    try {
      const response = await fetch(`../../docs/features/${feature}/manifest.json`);
      if (!response.ok) throw new Error(`Failed to load manifest for ${feature}`);
      const manifest = await response.json();
      manifestCache.set(feature, manifest);
      return manifest;
    } catch (error) {
      console.error(`Error loading ${feature} manifest:`, error);
      return {};
    }
  }

  // ============================================
  // POPULATE VARIATION DROPDOWN FROM MANIFEST KEYS
  // ============================================
  async function populateVariationDropdown(feature, variationSelect) {
    const manifest = await loadManifest(feature);
    const variationKeys = Object.keys(manifest).sort(); // Sorts "Variation 1", "Variation 2", etc.
    
    variationSelect.innerHTML = '<option value="" selected disabled>— Select variation —</option>';
    
    variationKeys.forEach(key => {
      const option = document.createElement('option');
      option.value = key; // Use the full key name like "Variation 1"
      option.textContent = key; // Display "Variation 1", "Variation 2", etc.
      
      // Optional: Show count in dropdown
      const count = manifest[key].length;
      if (count > 0) {
        option.textContent += ` (${count} ${count === 1 ? 'example' : 'examples'})`;
      }
      
      variationSelect.appendChild(option);
    });
  }

  // ============================================
  // POPULATE EXAMPLE DROPDOWN BASED ON SELECTED VARIATION
  // ============================================
  async function populateExamplesByVariation(feature, variationKey, exampleSelect) {
    const manifest = await loadManifest(feature);
    const examples = manifest[variationKey] || [];
    
    exampleSelect.innerHTML = '<option value="" selected>— Select an example —</option>';
    exampleSelect.disabled = false;
    
    examples.forEach((ex, index) => {
      const option = document.createElement('option');
      option.value = `docs/features/${feature}/${ex.folder}/${ex.file}`;
      
      let displayName = `${index + 1}. ${ex.name}`;
      if (ex.badge) displayName += ` [${ex.badge}]`;
      
      option.textContent = displayName;
      option.dataset.folder = ex.folder;
      if (ex.badge) option.dataset.badge = ex.badge;
      
      exampleSelect.appendChild(option);
    });
    
    const countEl = document.querySelector(`[data-feature="${feature}"] .example-count`);
    if (countEl) {
      const count = examples.length;
      countEl.textContent = `${count} ${count === 1 ? 'example' : 'examples'} in ${variationKey}`;
    }
  }

  // ============================================
  // LOAD EXAMPLE CODE
  // ============================================
  async function loadExampleCode(filePath) {
    if (codeCache.has(filePath)) {
      return codeCache.get(filePath);
    }
    
    try {
      const response = await fetch(`../../${filePath}`);
      if (!response.ok) throw new Error(`HTTP ${response.status}`);
      const content = await response.text();
      
      let code = cleanCodeForDisplay(content);
      
      codeCache.set(filePath, code);
      return code;
    } catch (error) {
      console.error(`Failed to load ${filePath}:`, error);
      return `// Failed to load example: ${filePath}\n// ${error.message}`;
    }
  }

  // ============================================
  // CLEAN CODE FOR DISPLAY
  // ============================================
  function cleanCodeForDisplay(content) {
    let lines = content.split('\n');
    
    while (lines.length > 0 && lines[0].trim() === '') lines.shift();
    while (lines.length > 0 && lines[lines.length - 1].trim() === '') lines.pop();
    
    return lines.join('\n');
  }

  // ============================================
// SETUP EVENT LISTENERS
// ============================================
function setupEventListeners(feature) {
  const container = document.querySelector(`[data-feature="${feature}"]`);
  if (!container) return;
  
  const variationSelect = container.querySelector('.variation-selector');
  const exampleSelect = container.querySelector('.example-selector');
  const loader = container.querySelector('.example-loader');
  const errorDiv = container.querySelector('.example-error');
  const preBlock = container.querySelector('pre.line-numbers');
  const codeElement = container.querySelector('.example-code');
  const copyBtn = container.querySelector('.copy-code-btn'); // ✅ Defined here
  
  // Populate variation dropdown on page load
  if (variationSelect) {
    populateVariationDropdown(feature, variationSelect);
  }
  
  variationSelect?.addEventListener('change', async (e) => {
    const variationKey = e.target.value;
    if (!variationKey) return;
    
    exampleSelect.value = '';
    preBlock?.classList.add('d-none');
    
    exampleSelect.innerHTML = '<option value="" selected>Loading examples...</option>';
    exampleSelect.disabled = true;
    
    await populateExamplesByVariation(feature, variationKey, exampleSelect);
  });
  
  exampleSelect?.addEventListener('change', async (e) => {
    const filePath = e.target.value;
    if (!filePath) {
      preBlock?.classList.add('d-none');
      return;
    }
    
    loader?.classList.remove('d-none');
    errorDiv?.classList.add('d-none');
    preBlock?.classList.add('d-none');
    
    try {
      const code = await loadExampleCode(filePath);
      codeElement.textContent = code;
      preBlock?.classList.remove('d-none');
      
      if (window.Prism) {
        codeElement.classList.remove('language-csharp');
        void codeElement.offsetWidth;
        codeElement.classList.add('language-csharp');
        Prism.highlightElement(codeElement);
      }
      
    } catch (error) {
      errorDiv.textContent = `Error loading example: ${error.message}`;
      errorDiv.classList.remove('d-none');
    } finally {
      loader?.classList.add('d-none');
    }
  });
  
  // ✅ FIXED: Copy button event listener - now inside setupEventListeners
  copyBtn?.addEventListener('click', () => {
    if (!codeElement?.textContent) return;
    
    navigator.clipboard.writeText(codeElement.textContent);
    
    // Add success class
    copyBtn.classList.add('btn-success');
    const icon = copyBtn.querySelector('i');
    icon.className = 'fa-solid fa-check';
    
    // Remove after 2 seconds
    setTimeout(() => {
      copyBtn.classList.remove('btn-success');
      icon.className = 'fa-regular fa-copy';
    }, 2000);
  });
  
  variationSelect?.addEventListener('change', (e) => {
    if (!e.target.value) {
      exampleSelect.innerHTML = '<option value="" selected>— First select a variation —</option>';
      exampleSelect.disabled = true;
      preBlock?.classList.add('d-none');
      
      const countEl = container.querySelector('.example-count');
      if (countEl) countEl.textContent = '';
    }
  });
}
  



  // ============================================
  // INITIALIZE ALL FEATURES
  // ============================================
  async function initializeAllFeatures() {
    const features = [
      'datetime', 'number', 'naturalstring', 'plainstring',
      'ipaddress', 'percentage', 'filesize', 'version', 'currency',
      'readexcel', 'writeexcel'
    ];
    
    for (const feature of features) {
      setupEventListeners(feature);
    }
  }

  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initializeAllFeatures);
  } else {
    initializeAllFeatures();
  }
})();