document.addEventListener("DOMContentLoaded", function () {

    // Xử lý sự kiện submit form đăng ký
    const form = document.querySelector("form");
    const fields = [
        { id: "HoTen", name: "Họ và tên" },
        { id: "TenTaiKhoan", name: "Tên tài khoản" },
        { id: "Email", name: "Email", type: "email" },
        { id: "MatKhau", name: "Mật khẩu" },
        { id: "XacNhanMatKhau", name: "Xác nhận mật khẩu" },
        { id: "SoDienThoai", name: "Số điện thoại", type: "phone" }
    ];
    const vaiTro = document.querySelectorAll('input[name="VaiTro"]');

    form.addEventListener("submit", function (e) {
        let isValid = true;

        // Xóa lỗi cũ
        document.querySelectorAll('[data-valmsg-for]').forEach(span => {
            span.textContent = "";
        });

        // Kiểm tra từng trường
        fields.forEach(field => {
            const input = document.querySelector(`#${field.id}`);
            const span = document.querySelector(`[data-valmsg-for="${field.id}"]`);
            if (!input || !span) return;

            const value = input.value.trim();
            if (value === "") {
                span.textContent = `Vui lòng nhập ${field.name}.`;
                isValid = false;
                return;
            }

            // Kiểm tra email
            if (field.type === "email" && value !== "") {
                const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailRegex.test(value)) {
                    span.textContent = "Email không hợp lệ.";
                    isValid = false;
                }
            }

            // Kiểm tra số điện thoại
            if (field.type === "phone" && value !== "") {
                const phoneRegex = /^(0|\+84)[0-9]{9,10}$/;
                if (!phoneRegex.test(value)) {
                    span.textContent = "Số điện thoại không hợp lệ.";
                    isValid = false;
                }
            }
        });

        // Kiểm tra mật khẩu xác nhận
        const matKhau = document.querySelector("#MatKhau");
        const xacNhanMatKhau = document.querySelector("#XacNhanMatKhau");
        const spanConfirm = document.querySelector('[data-valmsg-for="XacNhanMatKhau"]');
        if (matKhau.value.trim() !== "" && xacNhanMatKhau.value.trim() !== "" && matKhau.value !== xacNhanMatKhau.value) {
            spanConfirm.textContent = "Mật khẩu xác nhận không khớp.";
            isValid = false;
        }

        if (!isValid) {
            e.preventDefault();
        }
    });


    console.log("Register page loaded!");
});
