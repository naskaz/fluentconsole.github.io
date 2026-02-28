// /js/velocityexcel.js — Product-specific logic for VelocityExcel

(() => {
  "use strict";

  const CONFIG = {
    name: "VelocityExcel",
    version: "1.0.3",
    sectionIds: [
      "introduction",
      "installation",
      "read-excel",
      "write-excel"
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

// Animate chevron on Examples toggle
document.addEventListener("DOMContentLoaded", () => {
  const examplesToggle = document.querySelector(
    '#sidebar a[href="#examples-collapse"]',
  );
  const chevron = examplesToggle?.querySelector("i.fa-chevron-down");
  if (!chevron) return;

  const collapseEl = document.getElementById("examples-collapse");
  if (collapseEl) {
    collapseEl.addEventListener("shown.bs.collapse", () => {
      chevron.classList.add("rotated");
    });
    collapseEl.addEventListener("hidden.bs.collapse", () => {
      chevron.classList.remove("rotated");
    });
  }
});