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

    function clickNavigation(event) {
        event.preventDefault();
        const index = Array.from(navLinks).indexOf(event.target);
        showImage(index);
        clearInterval(intervalId);
        intervalId = setInterval(nextImage, 6000);
    }

    navLinks.forEach(link => link.addEventListener("click", clickNavigation));
    function nextImage() {
        currentIndex = (currentIndex + 1) % images.length;
        showImage(currentIndex);
    }

    function startSlider() {
        images[0].classList.add('active');
            // Change image every 6 seconds
        intervalId = setInterval(nextImage, 6000);
    }
    startSlider();
});
