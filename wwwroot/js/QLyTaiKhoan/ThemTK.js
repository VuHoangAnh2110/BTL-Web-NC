document.addEventListener("DOMContentLoaded", function () {
    // Xử lý form thêm tài khoản
    const form = document.querySelector("#formThemTK");
    
    if (form) {
        form.addEventListener("submit", function (e) {
            let isValid = true;
            
            // Xóa thông báo lỗi cũ
            document.querySelectorAll(".is-invalid").forEach(el => {
                el.classList.remove("is-invalid");
            });
            document.querySelectorAll(".text-danger").forEach(el => {
                if (!el.hasAttribute("asp-validation-summary")) {
                    el.textContent = "";
                }
            });
            
            // Kiểm tra tên tài khoản
            const tenTaiKhoan = document.querySelector("#TenTaiKhoan");
            if (!tenTaiKhoan.value.trim()) {
                document.querySelector("[data-valmsg-for='TenTaiKhoan']").textContent = "Vui lòng nhập tên tài khoản";
                tenTaiKhoan.classList.add("is-invalid");
                isValid = false;
            }
            
            // Kiểm tra họ tên
            const hoTen = document.querySelector("#HoTen");
            if (!hoTen.value.trim()) {
                document.querySelector("[data-valmsg-for='HoTen']").textContent = "Vui lòng nhập họ và tên";
                hoTen.classList.add("is-invalid");
                isValid = false;
            }
            
            // Kiểm tra email
            const email = document.querySelector("#Email");
            if (!email.value.trim()) {
                document.querySelector("[data-valmsg-for='Email']").textContent = "Vui lòng nhập email";
                email.classList.add("is-invalid");
                isValid = false;
            } else {
                const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailRegex.test(email.value.trim())) {
                    document.querySelector("[data-valmsg-for='Email']").textContent = "Email không hợp lệ";
                    email.classList.add("is-invalid");
                    isValid = false;
                }
            }
            
            // Kiểm tra mật khẩu
            const matKhau = document.querySelector("#MatKhau");
            if (!matKhau.value) {
                document.querySelector("[data-valmsg-for='MatKhau']").textContent = "Vui lòng nhập mật khẩu";
                matKhau.classList.add("is-invalid");
                isValid = false;
            } else if (matKhau.value.length < 8) {
                document.querySelector("[data-valmsg-for='MatKhau']").textContent = "Mật khẩu phải có ít nhất 8 ký tự";
                matKhau.classList.add("is-invalid");
                isValid = false;
            } else if (!/[A-Za-z]/.test(matKhau.value) || !/[0-9]/.test(matKhau.value)) {
                document.querySelector("[data-valmsg-for='MatKhau']").textContent = "Mật khẩu phải chứa cả chữ và số";
                matKhau.classList.add("is-invalid");
                isValid = false;
            } else if (!/[^A-Za-z0-9]/.test(matKhau.value)) {
                document.querySelector("[data-valmsg-for='MatKhau']").textContent = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt";
                matKhau.classList.add("is-invalid");
                isValid = false;
            }
            
            // Kiểm tra xác nhận mật khẩu
            const xacNhanMatKhau = document.querySelector("#XacNhanMatKhau");
            if (!xacNhanMatKhau.value) {
                document.querySelector("[data-valmsg-for='XacNhanMatKhau']").textContent = "Vui lòng xác nhận mật khẩu";
                xacNhanMatKhau.classList.add("is-invalid");
                isValid = false;
            } else if (xacNhanMatKhau.value !== matKhau.value) {
                document.querySelector("[data-valmsg-for='XacNhanMatKhau']").textContent = "Mật khẩu xác nhận không khớp";
                xacNhanMatKhau.classList.add("is-invalid");
                isValid = false;
            }
            
            // Kiểm tra số điện thoại nếu có nhập
            const soDienThoai = document.querySelector("#SoDienThoai");
            if (soDienThoai.value.trim()) {
                const phoneRegex = /^(0|\+84)[0-9]{9,10}$/;
                if (!phoneRegex.test(soDienThoai.value.trim())) {
                    document.querySelector("[data-valmsg-for='SoDienThoai']").textContent = "Số điện thoại không hợp lệ";
                    soDienThoai.classList.add("is-invalid");
                    isValid = false;
                }
            }
            
            if (!isValid) {
                e.preventDefault();
            }
        });
    }
});