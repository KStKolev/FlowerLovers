// Create scrolling functionality for navigation bar.

const navbar = document.querySelector(".navbar");
let lastScrollY = window.scrollY;

window.addEventListener("scroll", () => {
    const currentScrollY = window.scrollY;

    if (currentScrollY === 0) {
        navbar.classList.remove("nav-hidden");
    } else {
        if (lastScrollY > currentScrollY) {
            navbar.classList.add("nav-hidden");
        } else {
            navbar.classList.remove("nav-hidden");
        }
    }

    lastScrollY = currentScrollY;
});
