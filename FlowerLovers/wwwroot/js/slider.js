document.addEventListener("DOMContentLoaded", function () {
    const images = document.querySelectorAll(".slider img");
    const navLinks = document.querySelectorAll(".slider-nav a");
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
