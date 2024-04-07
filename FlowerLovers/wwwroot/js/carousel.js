// Select the control buttons for changing the images.
const buttons = document.querySelectorAll("[data-carousel-button]");

buttons.forEach(button => {
    // Create a delegate, which changes the current image.
    button.addEventListener("click", () => {
        const offset = button.dataset.carouselButton === "next" ? 1 : -1;
        const slides = button.closest("[data-carousel]").querySelector("[data-slides]");
        const activeSlide = slides.querySelector("[data-active]");
        let newIndex = [...slides.children].indexOf(activeSlide) + offset;
        if (newIndex < 0) {
            newIndex = slides.children.length - 1;
        }
        else if (newIndex >= slides.children.length) {
            newIndex = 0;
        }

           // Change the attributes in order to swap between the images.
        slides.children[newIndex].dataset.active = true;
        delete activeSlide.dataset.active;
    })
}); 