// /js/intellidatasort.js — Product-specific logic for IntelliDataSort

(() => {
  "use strict";

  const CONFIG = {
    name: "IntelliDataSort",
    version: "1.0.0",
    intro:
      "",
    install: "",
    usage: "",
    // All section IDs (including nested features)
    sectionIds: [
      "introduction",
      "installation",
      "basic-usage",
      "number",
      "datetime",
      "naturalstring",
      "plainstring",
      "ipaddress",
      "percentage",
      "filesize",
      "version",
      "currency",
    ],
  };

  function updateStaticContent() {
    document.title = `${CONFIG.name} — Documentation`;

    const main = document.querySelector("main");
    if (main) {
      const h1 = main.querySelector("h1");
      if (h1) h1.textContent = `${CONFIG.name} Documentation`;

      const badge = main.querySelector(".badge.bg-secondary");
      if (badge) badge.textContent = `v${CONFIG.version}`;
    }

    // Update static content
    // const introP = document.getElementById("introduction")?.querySelector("p");
    // if (introP) introP.textContent = CONFIG.intro;

    // const installCode = document
    //   .getElementById("installation")
    //   ?.querySelector("pre code");
    // if (installCode) installCode.textContent = CONFIG.install;

    // const usageCode = document
    //   .getElementById("basic-usage")
    //   ?.querySelector("pre code");
    // if (usageCode) usageCode.textContent = CONFIG.usage;
  }

  function initSectionTabs() {
    const sidebarLinks = document.querySelectorAll('#sidebar a[href^="#"]');
    const allSectionIds = CONFIG.sectionIds;

    function showSection(id) {
      // Hide all sections
      allSectionIds.forEach((sid) => {
        const el = document.getElementById(sid);
        if (el) el.classList.remove("active");
      });

      // Show target
      const target = document.getElementById(id);
      if (target) target.classList.add("active");

      // Update active state in sidebar (including nested links)
      sidebarLinks.forEach((link) => {
        const href = link.getAttribute("href");
        link.classList.toggle("active", href === `#${id}`);
      });
    }

    // Initialize with Introduction
    showSection("introduction");

    sidebarLinks.forEach((link) => {
      link.addEventListener("click", (e) => {
        e.preventDefault();

        const id = link.getAttribute("href")?.substring(1);
        if (!id || !allSectionIds.includes(id)) return;

        history.pushState(null, '', `#${id}`);

        showSection(id);

        const container = document.getElementById("main-content");
        const target = document.getElementById(id);

        if (container && target) {
          container.scrollTo({
            top: target.offsetTop,
            behavior: "smooth",
          });
        }

        if (typeof window.reloadFeatureExamples === 'function') {
          window.reloadFeatureExamples();
        }


      });

    });

    // Handle direct hash navigation
    const handleHash = () => {
      const hash = window.location.hash.substring(1);
      if (hash && allSectionIds.includes(hash)) {
        showSection(hash);
      }
    };
    window.addEventListener("hashchange", handleHash);
    handleHash();
  }

  // Initialize when DOM is ready
  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", () => {
      updateStaticContent();
      initSectionTabs();
    });
  } else {
    updateStaticContent();
    initSectionTabs();
  }
})();

// Optional: animate chevron on Features toggle
document.addEventListener("DOMContentLoaded", () => {
  const featuresToggle = document.querySelector(
    '#sidebar a[href="#features-collapse"]',
  );
  const chevron = featuresToggle?.querySelector("i.fa-chevron-down");
  if (!chevron) return;

  // Initial state: collapsed → chevron down
  // When opened, rotate 180°; when closed, reset
  const collapseEl = document.getElementById("features-collapse");
  if (collapseEl) {
    collapseEl.addEventListener("shown.bs.collapse", () => {
      chevron.classList.add("rotated");
    });
    collapseEl.addEventListener("hidden.bs.collapse", () => {
      chevron.classList.remove("rotated");
    });
  }
});
