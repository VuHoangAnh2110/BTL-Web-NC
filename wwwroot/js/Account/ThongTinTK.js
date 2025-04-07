document.addEventListener("DOMContentLoaded", function() {

    // Xử lý form đổi mật khẩu
    const formDoiMatKhau = document.getElementById("formDoiMatKhau");
    if (formDoiMatKhau) {
        formDoiMatKhau.addEventListener("submit", async function(e) {
            e.preventDefault();
            
            // Reset lỗi
            document.querySelectorAll(".invalid-feedback").forEach(el => el.textContent = "");
            document.querySelectorAll(".form-control").forEach(el => el.classList.remove("is-invalid"));
            
            // Lấy dữ liệu
            const matKhauCu = document.getElementById("matKhauCu").value.trim();
            const matKhauMoi = document.getElementById("matKhauMoi").value.trim();
            const xacNhanMatKhau = document.getElementById("xacNhanMatKhau").value.trim();
            
            let isValid = true;
            
            // Kiểm tra mật khẩu cũ
            if (!matKhauCu) {
                document.getElementById("matKhauCu").classList.add("is-invalid");
                document.getElementById("errMatKhauCu").textContent = "Vui lòng nhập mật khẩu hiện tại";
                isValid = false;
            }
            
            // Kiểm tra mật khẩu mới
            if (!matKhauMoi) {
                document.getElementById("matKhauMoi").classList.add("is-invalid");
                document.getElementById("errMatKhauMoi").textContent = "Vui lòng nhập mật khẩu mới";
                isValid = false;
            } else if (matKhauMoi.length < 8) {
                document.getElementById("matKhauMoi").classList.add("is-invalid");
                document.getElementById("errMatKhauMoi").textContent = "Mật khẩu phải có ít nhất 8 ký tự";
                isValid = false;
            } else if (!/[A-Za-z]/.test(matKhauMoi) || !/[0-9]/.test(matKhauMoi)) {
                document.getElementById("matKhauMoi").classList.add("is-invalid");
                document.getElementById("errMatKhauMoi").textContent = "Mật khẩu phải chứa cả chữ và số";
                isValid = false;
            } else if (!/[^A-Za-z0-9]/.test(matKhauMoi)) {
                document.getElementById("matKhauMoi").classList.add("is-invalid");
                document.getElementById("errMatKhauMoi").textContent = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt";
                isValid = false;
            }
            
            // Kiểm tra xác nhận mật khẩu
            if (!xacNhanMatKhau) {
                document.getElementById("xacNhanMatKhau").classList.add("is-invalid");
                document.getElementById("errXacNhanMatKhau").textContent = "Vui lòng xác nhận mật khẩu mới";
                isValid = false;
            } else if (xacNhanMatKhau !== matKhauMoi) {
                document.getElementById("xacNhanMatKhau").classList.add("is-invalid");
                document.getElementById("errXacNhanMatKhau").textContent = "Xác nhận mật khẩu không khớp";
                isValid = false;
            }
            
            if (!isValid) return;
            
            try {
                const response = await fetch("/Account/DoiMatKhau", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({
                        matKhauCu,
                        matKhauMoi,
                        xacNhanMatKhau
                    })
                });
                
                const result = await response.json();
                
                if (result.success) {
                    Swal.fire({
                        icon: "success",
                        title: "Thành công!",
                        text: result.message,
                    }).then(() => {
                        bootstrap.Modal.getInstance(document.getElementById("modalDoiMatKhau")).hide();
                        formDoiMatKhau.reset();
                    });
                } else {
                    if (result.errors) {
                        // Hiển thị lỗi cụ thể
                        if (result.errors.matKhauCu) {
                            document.getElementById("matKhauCu").classList.add("is-invalid");
                            document.getElementById("errMatKhauCu").textContent = result.errors.matKhauCu;
                        }
                        if (result.errors.matKhauMoi) {
                            document.getElementById("matKhauMoi").classList.add("is-invalid");
                            document.getElementById("errMatKhauMoi").textContent = result.errors.matKhauMoi;
                        }
                        if (result.errors.xacNhanMatKhau) {
                            document.getElementById("xacNhanMatKhau").classList.add("is-invalid");
                            document.getElementById("errXacNhanMatKhau").textContent = result.errors.xacNhanMatKhau;
                        }
                    } else {
                        Swal.fire({
                            icon: "error",
                            title: "Lỗi!",
                            text: result.message || "Đã xảy ra lỗi khi đổi mật khẩu",
                        });
                    }
                }
            } catch (error) {
                Swal.fire({
                    icon: "error",
                    title: "Lỗi!",
                    text: "Đã xảy ra lỗi khi kết nối đến máy chủ",
                });
            }
        });
    }





});