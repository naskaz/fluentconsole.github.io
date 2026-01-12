(function () {
  const link = document.getElementById("shareSiteLink");
  if (!link) return;

  link.addEventListener("click", function (e) {
    e.preventDefault();

    const url = "https://naskaz.github.io/fluentconsole.github.io";

    if (navigator.share) {
      navigator.share({
        title: "FluentConsoleBuilder",
        text: "Professional, data-aware console output for .NET",
        url: url,
      });
    } else {
      navigator.clipboard.writeText(url).then(() => {
        alert("Link copied to clipboard");
      });
    }
  });
})();

const currentYear = new Date().getFullYear();
document.getElementById("year").textContent = currentYear;

document
  .querySelectorAll('[data-bs-toggle="tooltip"]')
  .forEach((el) => new bootstrap.Tooltip(el));

const toggler = document.querySelector(".navbar-toggler");
const navCollapse = document.getElementById("nav");

toggler.addEventListener("click", () => {
  toggler.innerHTML = toggler.classList.contains("collapsed")
    ? '<i class="fa-solid fa-bars"></i>'
    : '<i class="fa-solid fa-xmark"></i>';
});

navCollapse.querySelectorAll(".nav-link").forEach((link) => {
  link.addEventListener("click", () => {
    const bsCollapse = bootstrap.Collapse.getInstance(navCollapse);
    if (bsCollapse) {
      bsCollapse.hide();
    }

    // Reset icon back to hamburger
    toggler.classList.add("collapsed");
    toggler.innerHTML = '<i class="fa-solid fa-bars"></i>';
  });
});
