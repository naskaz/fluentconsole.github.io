// fluidwidth.js
(() => {
  "use strict";

  const CONFIG = {
    name: "FluidWidth",
    version: "1.1.1",
    intro:
      "FluidWidth provides accurate character width calculation for Unicode, emojis, CJK characters, and ANSI sequences in .NET console applications.",
    install: "Install-Package FluidWidth",
    usage: `using FluidWidth;\n\nstring text = "Hello 👋 世界";\nint width = TextMeasurer.GetDisplayWidth(text);\nConsole.WriteLine($"Display width: {width}");`,
    sidebarItems: [
      { id: "introduction", text: "Introduction" },
      { id: "installation", text: "Installation" },
      { id: "basic-usage", text: "Basic Usage" },
      { id: "unicode-support", text: "Unicode Support" }
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

    // Update content
    const introP = document.getElementById("introduction")?.querySelector("p");
    if (introP) introP.textContent = CONFIG.intro;

    const installCode = document
      .getElementById("installation")
      ?.querySelector("pre code");
    if (installCode) installCode.textContent = CONFIG.install;

    const usageCode = document
      .getElementById("basic-usage")
      ?.querySelector("pre code");
    if (usageCode) usageCode.textContent = CONFIG.usage;
  }

  function initSectionTabs() {
    const sidebarLinks = document.querySelectorAll("#sidebar .nav-link");

    function showSection(id) {
      // Hide all by removing .active
      const allSections = [
        "introduction",
        "installation",
        "basic-usage",
        "unicode-support",
      ];
      allSections.forEach((sid) => {
        const el = document.getElementById(sid);
        if (el) el.classList.remove("active");
      });

      // Show target
      const target = document.getElementById(id);
      if (target) {
        target.classList.add("active"); // ← only class, no inline style
      }

      // Update sidebar
      sidebarLinks.forEach((link) => {
        link.classList.toggle("active", link.getAttribute("href") === `#${id}`);
      });
    }

    // Initialize
    showSection("introduction");

    // Click handlers
    sidebarLinks.forEach((link) => {
      link.addEventListener("click", (e) => {
        e.preventDefault();
        const href = link.getAttribute("href");
        if (!href || href === "#") return;
        const id = href.substring(1);
        showSection(id);

        const container = document.getElementById("main-content");
        if (container) {
          container.scrollTo({
            //top: el.offsetTop,
            behavior: "smooth",
          });
        }
        
      });
    });

    // Hash handling
    const handleHash = () => {
      const hash = window.location.hash.substring(1);
      if (hash) showSection(hash);
    };
    window.addEventListener("hashchange", handleHash);
    handleHash();
  }

  // Wait for DOM fully loaded
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
