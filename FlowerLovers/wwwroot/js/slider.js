document.addEventListener("DOMContentLoaded", function () {
    const sliderContainer = document.querySelector(".slider");
    const images = sliderContainer ? sliderContainer.querySelectorAll("img") : null;
    const navLinks = sliderContainer ? sliderContainer.querySelectorAll(".slider-nav a") : null;

    if (!sliderContainer || !images || !navLinks) {
        return;
    }

    let currentIndex = 0;
    let intervalId;

    function showImage(index) {
        images.forEach(image => image.classList.remove('active'));
        images[index].classList.add('active');
        currentIndex = index;
    }

    function navClickHandler(event) {
        event.preventDefault();
        const index = Array.from(navLinks).indexOf(event.target);
        showImage(index);
        clearInterval(intervalId);
        intervalId = setInterval(nextImage, 3000);
    }

    navLinks.forEach(link => link.addEventListener("click", navClickHandler));

    function nextImage() {
        currentIndex = (currentIndex + 1) % images.length;
        showImage(currentIndex);
    }

    function startSlider() {
        images[0].classList.add('active');
        intervalId = setInterval(nextImage, 3000);
    }

    startSlider();
});
