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

    // Xử lý sự kiện submit form đăng nhâp
    const form = document.querySelector("form");
    const usernameInput = form.querySelector("input[name='UsernameOrEmail']");
    const passwordInput = form.querySelector("input[name='Password']");
    const usernameError = form.querySelector("span[data-valmsg-for='UsernameOrEmail']");
    const passwordError = form.querySelector("span[data-valmsg-for='Password']");

    form.addEventListener("submit", function (e) {
        let isValid = true;

        // Reset lỗi
        usernameError.textContent = "";
        passwordError.textContent = "";
        usernameInput.classList.remove("is-invalid");
        passwordInput.classList.remove("is-invalid");

        // Kiểm tra UsernameOrEmail
        const username = usernameInput.value.trim();
        if (username === "") {
            usernameError.textContent = "Vui lòng nhập email hoặc tên tài khoản.";
            usernameInput.classList.add("is-invalid");
            isValid = false;
        } else {
            const specialChars = username.match(/[^a-zA-Z0-9]/g);
            if (specialChars && specialChars.length > 4) {
                usernameError.textContent = "Không được nhập quá 4 ký tự đặc biệt.";
                usernameInput.classList.add("is-invalid");
                isValid = false;
            }
        }

        // Kiểm tra Password
        const password = passwordInput.value;
        if (password === "") {
            passwordError.textContent = "Vui lòng nhập mật khẩu.";
            passwordInput.classList.add("is-invalid");
            isValid = false;
        } else {
            if (password.length < 8) {
                passwordError.textContent = "Mật khẩu phải có ít nhất 8 ký tự.";
                passwordInput.classList.add("is-invalid");
                isValid = false;
            } else if (!/[A-Za-z]/.test(password) || !/[0-9]/.test(password)) {
                passwordError.textContent = "Mật khẩu phải chứa cả chữ và số.";
                passwordInput.classList.add("is-invalid");
                isValid = false;
            } else if (!/[^A-Za-z0-9]/.test(password)) {
                passwordError.textContent = "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt.";
                passwordInput.classList.add("is-invalid");
                isValid = false;
            }
        }

        // Kiểm tra file (nếu có input file)
        const fileInputs = form.querySelectorAll("input[type='file']");
        for (let input of fileInputs) {
            if (input.value) {
                showToast("error", "Vui lòng không upload file ở trang đăng nhập.");
                isValid = false;
                break;
            }
        }

        // Nếu có lỗi thì chặn submit
        if (!isValid) {
            e.preventDefault();
        }
    });

    console.log("Login page loaded!");
});
