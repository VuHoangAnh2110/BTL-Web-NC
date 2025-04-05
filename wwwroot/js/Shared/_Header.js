$(document).ready(function () {
    function loadNotificationCount() {
        $.ajax({
            url: "/Notification/GetNotificationCount",
            type: "GET",
            success: function (data) {
                if (data.count > 0) {
                    $("#notificationBadge").text(data.count).show();
                } else {
                    $("#notificationBadge").hide();
                }
            },
            error: function (xhr, status, error) {
                console.error("Lỗi AJAX:", xhr.responseText);
            }
        });
    }

    function loadNotifications() {
        $.ajax({
            url: "/Notification/GetNotifications",
            type: "GET",
            success: function (data) {
                let notificationList = $("#notificationList");
                notificationList.empty();

                notificationList.append(`
                    <li class="dropdown-header text-center fw-bold">Thông Báo</li>
                    <li><hr class="dropdown-divider"></li>
                `);

                if (data.length > 0) {
                    data.forEach(function (notification, index) {
                        let itemClass = notification.daXem ? "text-secondary" : "text-dark fw-bold";
                        notificationList.append(`
                            <li>
                                <a class="dropdown-item ${itemClass}" href="/Notification/Detail/${notification.id}" data-id="${notification.id}">
                                    ${notification.title}
                                </a>
                            </li>
                        `);
                    
                    });

                    notificationList.append(`
                        <li><hr class="dropdown-divider"></li>
                        <li><a class="dropdown-item text-center text-primary" href="/Account/Notification">Xem tất cả</a></li>
                    `);
                } else {
                    notificationList.append(`<li class="dropdown-item text-center"><em>Không có thông báo</em></li>`);
                } 
                if (data.length > 0) {
                    data.forEach(function (notification, index) {
                        let itemClass = notification.daXem ? "bg-light text-secondary" : "bg-warning text-dark fw-bold";
                        
                        // Giới hạn số ký tự hiển thị (ví dụ: 50 ký tự)
                        let titleShort = notification.title.length > 30 ? notification.title.substring(0, 30) + "..." : notification.title;

                        notificationList.append(`
                            <li class="dropdown-item ${itemClass}">
                                <a class="text-dark text-decoration-none" href="/Notification/Detail/${notification.id}" data-id="${notification.id}">
                                    ${titleShort}
                                </a>
                            </li>
                        `);
                    });

                    notificationList.append(`
                        <li><hr class="dropdown-divider"></li>
                        <li><a class="dropdown-item text-center text-primary text-decoration-none" href="/Account/Notification">Xem tất cả</a></li>
                    `);
                } else {
                    notificationList.append(`<li class="dropdown-item text-center"><em>Không có thông báo</em></li>`);
                }


            },
            error: function (xhr, status, error) {
                console.error("Lỗi AJAX:", xhr.responseText);
            }
        });
    }

    $("#notificationDropdown").on("click", function () {
        loadNotifications();
    });

    // Đánh dấu thông báo là đã đọc khi click vào
    $(document).on("click", "#notificationList a", function () {
        let id = $(this).data("id");
        $.post("/Notification/MarkAsRead", { id: id }, function () {
            loadNotificationCount();
        });
    });

    loadNotificationCount();
});