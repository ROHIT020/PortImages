(function () {
    "use strict";

    window.onload = function () {

        // Preloader JS
        const getPreloaderId = document.getElementById('preloader');
        if (getPreloaderId) {
            getPreloaderId.style.display = 'none';
        }

        // Header Sticky
        const getHeaderId = document.getElementById("header-area");
        if (getHeaderId) {
            window.addEventListener('scroll', event => {
                const height = 150;
                const { scrollTop } = event.target.scrollingElement;
                document.querySelector('#header-area').classList.toggle('sticky', scrollTop >= height);
            });
        }

        // Header Sticky
        const getNavbarId = document.getElementById("navbar");
        if (getNavbarId) {
            window.addEventListener('scroll', event => {
                const height = 150;
                const { scrollTop } = event.target.scrollingElement;
                document.querySelector('#navbar').classList.toggle('sticky', scrollTop >= height);
            });
        }
    };

    // Menu JS
    let menu, animate;

    (function () {
        // Initialize menu
        let layoutMenuEl = document.querySelectorAll('#layout-menu');
        layoutMenuEl.forEach(function (element) {
            menu = new Menu(element, {
                orientation: 'vertical',
                closeChildren: false
            });
            // Change parameter to true if you want scroll animation
            window.Helpers.scrollToActive((animate = false));
            window.Helpers.mainMenu = menu;
        });

    })();

    // Sidebar Burger Button
    const getSidebarBurgerMenuId = document.getElementById('sidebar-burger-menu');
    if (getSidebarBurgerMenuId) {
        const switchtoggle = document.querySelector(".sidebar-burger-menu");
        switchtoggle.addEventListener("click", function () {
            if (document.body.getAttribute("sidebar-data-theme") === "sidebar-hide") {
                document.body.setAttribute("sidebar-data-theme", "sidebar-show");
            } else {
                document.body.setAttribute("sidebar-data-theme", "sidebar-hide");
            }
        });
    }

    // Sidebar Burger Close Button
    const getSidebarBurgerMenuCloseId = document.getElementById('sidebar-burger-menu-close');
    if (getSidebarBurgerMenuCloseId) {
        const switchtoggle = document.querySelector(".sidebar-burger-menu-close");
        switchtoggle.addEventListener("click", function () {
            if (document.body.getAttribute("sidebar-data-theme") === "sidebar-hide") {
                document.body.setAttribute("sidebar-data-theme", "sidebar-show");
            } else {
                document.body.setAttribute("sidebar-data-theme", "sidebar-hide");
            }
        });
    }

    // Header Burger Button
    const getHeaderBurgerMenuId = document.getElementById('header-burger-menu');
    if (getHeaderBurgerMenuId) {
        const switchtoggle = document.querySelector(".header-burger-menu");
        switchtoggle.addEventListener("click", function () {
            if (document.body.getAttribute("sidebar-data-theme") === "sidebar-hide") {
                document.body.setAttribute("sidebar-data-theme", "sidebar-show");
            } else {
                document.body.setAttribute("sidebar-data-theme", "sidebar-hide");
            }
        });
    }

    // Init BS Tooltip
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });


    // Right Sidebar
    const getRightSidebarId = document.getElementById('right-sidebar');
    if (getRightSidebarId) {
        const switchtoggle = document.querySelector(".right-sidebar");
        const savedTheme = localStorage.getItem("fila_theme");
        if (savedTheme) {
            document.body.setAttribute("right-sidebar-data-theme", savedTheme);
        }
        switchtoggle.addEventListener("click", function () {
            if (document.body.getAttribute("right-sidebar-data-theme") === "right-sidebar-normal") {
                document.body.setAttribute("right-sidebar-data-theme", "right-sidebar-right");
                localStorage.setItem("fila_theme", "right-sidebar-right");
            } else {
                document.body.setAttribute("right-sidebar-data-theme", "right-sidebar-normal");
                localStorage.setItem("fila_theme", "right-sidebar-normal");
            }
        });
    }

    // Menu Left Right Slide JS
    const geMenuLeftRightSlideId = document.getElementById('menu');
    if (geMenuLeftRightSlideId) {

        document.addEventListener("DOMContentLoaded", () => {
            const menuItems = document.querySelectorAll("#menu > li");
            const prevBtn = document.getElementById("prev-btn");
            const nextBtn = document.getElementById("next-btn");
            let itemsPerPage = 8; // Default value
            let currentIndex = 0;

            // Function to update menu visibility
            function updateMenu() {
                menuItems.forEach((item, index) => {
                    item.style.display =
                        index >= currentIndex && index < currentIndex + itemsPerPage
                            ? "block"
                            : "none";
                });

                prevBtn.disabled = currentIndex === 0;
                nextBtn.disabled = currentIndex + itemsPerPage >= menuItems.length;
            }

            // Function to update itemsPerPage based on screen size
            function updateItemsPerPage() {
                if (window.matchMedia("(max-width: 992px)").matches) {
                    itemsPerPage = 7; // Show 1 item for small screens
                } else if (window.matchMedia("(max-width: 1024px)").matches) {
                    itemsPerPage = 7; // Show 2 items for medium screens
                } else {
                    itemsPerPage = 4; // Show 3 items for large screens
                }
                currentIndex = 0; // Reset index when itemsPerPage changes
                updateMenu();
            }

            // Event listeners for buttons
            prevBtn.addEventListener("click", () => {
                if (currentIndex > 0) {
                    currentIndex -= 1; // Move back by one item
                    updateMenu();
                }
            });

            nextBtn.addEventListener("click", () => {
                if (currentIndex + itemsPerPage < menuItems.length) {
                    currentIndex += 1; // Move forward by one item
                    updateMenu();
                }
            });

            // Add event listener for screen size changes
            window.addEventListener("resize", updateItemsPerPage);

            // Initial setup
            updateItemsPerPage();
        });
    }

    //menu link active 
    
})();

