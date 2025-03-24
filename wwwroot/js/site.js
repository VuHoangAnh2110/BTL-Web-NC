// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    // Hiển thị thông báo dạng toast ở góc phải trên cùng
    function showToast(type, message) {
        Swal.fire({
            toast: true,
            position: 'top-end', // Vị trí góc phải trên cùng
            icon: type, // 'success', 'error', 'warning', 'info'
            title: message,
            showConfirmButton: false,
            timer: 3000 // Tự động ẩn sau 3 giây
        });
    }

    
});
