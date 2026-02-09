(() => {
  "use strict";

  // Mobile sidebar toggle (for small screens)

  function initMobileSidebar() {
    const sidebar = document.getElementById("sidebar");
    const toggleBtn = document.getElementById("sidebar-toggle-btn");
    const closeBtn = document.getElementById("sidebar-close-btn");

    if (!sidebar || !toggleBtn) return;

    toggleBtn.addEventListener("click", () => {
      sidebar.classList.toggle("show");
      const icon = toggleBtn.querySelector("i");
      icon.className = sidebar.classList.contains("show")
        ? "fa-solid fa-chevron-left"
        : "fa-solid fa-chevron-right";
    });

    // ✅ Close button inside sidebar
    closeBtn?.addEventListener("click", () => {
      sidebar.classList.remove("show");
      toggleBtn.querySelector("i").className = "fa-solid fa-chevron-right";
    });

    // Close on outside click
    document.addEventListener("click", (e) => {
      if (
        window.innerWidth < 768 &&
        sidebar.classList.contains("show") &&
        !sidebar.contains(e.target) &&
        !toggleBtn.contains(e.target)
      ) {
        sidebar.classList.remove("show");
        toggleBtn.querySelector("i").className = "fa-solid fa-chevron-right";
      }
    });
  }




  // Back-to-top button (if present in DOM)
  function initBackToTop() {
    const backToTop = document.getElementById("back-to-top");
    if (!backToTop) return;

    const toggleVisibility = () => {
      backToTop.style.display = window.scrollY > 300 ? "block" : "none";
    };

    window.addEventListener("scroll", toggleVisibility);
    toggleVisibility(); // Initial check

    backToTop.addEventListener("click", (e) => {
      e.preventDefault();
      window.scrollTo({ top: 0, behavior: "smooth" });
    });
  }


  // Smooth scroll for internal hash links (#section)
  function initSmoothScroll() {
    // Only apply to links that point to IDs on the same page
    //document.querySelectorAll('a[href^="#"]')
    document
      .querySelectorAll('a[href^="#"]:not(#sidebar a)')
      .forEach((anchor) => {
        anchor.addEventListener("click", (e) => {
          const href = anchor.getAttribute("href");
          if (href === "#") return;

          const target = document.querySelector(href);
          if (!target) return;

          e.preventDefault();

          // Close mobile sidebar if open
          const sidebar = document.getElementById("sidebar");
          const toggleBtn = document.getElementById("sidebar-toggle-btn");
          if (sidebar?.classList.contains("show")) {
            sidebar.classList.remove("show");
            if (toggleBtn) {
              toggleBtn.querySelector("i").className =
                "fa-solid fa-chevron-right";
            }
          }

          // Scroll to target (account for fixed navbar ~56px + padding)
          const offsetTop = target.offsetTop - 80;
          window.scrollTo({ top: offsetTop, behavior: "smooth" });
        });
      });
  }


  // Toggle hamburger ↔ X icon INSTANTLY on click
  function initNavbarIconToggle() {
    const toggler = document.querySelector('.navbar-toggler');
    if (!toggler) return;

    // Ensure initial icon is bars
    let isOpen = false;
    toggler.innerHTML = '<i class="fa-solid fa-bars text-white"></i>';

    toggler.addEventListener('click', () => {
      isOpen = !isOpen;
      toggler.innerHTML = isOpen
        ? '<i class="fa-solid fa-xmark text-white"></i>'
        : '<i class="fa-solid fa-bars text-white"></i>';
    });

    // Optional: reset when nav links are clicked
    const navCollapse = document.getElementById('nav');
    if (navCollapse) {
      navCollapse.querySelectorAll('.nav-link').forEach(link => {
        link.addEventListener('click', () => {
          isOpen = false;
          toggler.innerHTML = '<i class="fa-solid fa-bars text-white"></i>';
        });
      });
    }
  }




  // Initialize all shared components
  function init() {
    initMobileSidebar();
    initBackToTop();
    initSmoothScroll();
    initNavbarIconToggle();
  }

  // Run when DOM is ready
  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", init);
  } else {
    init();
  }
})();
