document.addEventListener("DOMContentLoaded", function () {
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

    // Xử lý sự kiện submit form đăng ký
    const form = document.querySelector("form");
    const fields = [
        { id: "HoTen", name: "Họ và tên" },
        { id: "TenTaiKhoan", name: "Tên tài khoản" },
        { id: "Email", name: "Email", type: "email" },
        { id: "MatKhau", name: "Mật khẩu" },
        { id: "XacNhanMatKhau", name: "Xác nhận mật khẩu" }
    ];
    const vaiTro = document.querySelectorAll('input[name="VaiTro"]');

    form.addEventListener("submit", function (e) {
        let isValid = true;

        // Kiểm tra có tệp được tải lên không
        const fileInputs = Array.from(form.elements).filter(
            element => element.type === "file" && element.files.length > 0
        );
        if (fileInputs.length > 0) {
            e.preventDefault();
            showToast("error", "Không được tải lên tệp!")
            return;
        }

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
        });

        // Kiểm tra số điện thoại
        const soDienThoai = document.querySelector("#SoDienThoai");
        const spanSoDT = document.querySelector('[data-valmsg-for="SoDienThoai"]');
        if (soDienThoai && soDienThoai.value.trim() !== "") {
            const phoneRegex = /^(0|\+84)[0-9]{9,10}$/;
            if (!phoneRegex.test(soDienThoai.value.trim())) {
                spanSoDT.textContent = "Số điện thoại không hợp lệ.";
                isValid = false;
            }
        }

        // Kiểm tra định dạng mật khẩu 
        const matKhau = document.querySelector("#MatKhau");
        if (matKhau && matKhau.value.trim() !== "") {
            const password = matKhau.value.trim();
            const spanMatKhau = document.querySelector('[data-valmsg-for="MatKhau"]');
            
            if (password.length < 8) {
                spanMatKhau.textContent = "Mật khẩu phải có ít nhất 8 ký tự.";
                isValid = false;
            } else if (!/[A-Za-z]/.test(password) || !/[0-9]/.test(password)) {
                spanMatKhau.textContent = "Mật khẩu phải chứa cả chữ và số.";
                isValid = false;
            } else if (!/[^A-Za-z0-9]/.test(password)) {
                spanMatKhau.textContent = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt.";
                isValid = false;
            }
        }

        // Kiểm tra mật khẩu xác nhận
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
