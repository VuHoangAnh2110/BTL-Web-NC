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

    // Lắng nghe sự kiện click trên tất cả các nút có class "btn-khoa-tk"
    document.querySelectorAll(".btn-khoa-tk").forEach(button => {
        button.addEventListener("click", function () {
            let username = this.getAttribute("data-id"); // Lấy username từ thuộc tính data-id

            fetch(`/Account/LayThongTinTK?TenTaiKhoan=${encodeURIComponent(username)}`)
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    let account = data.taikhoan;
                    document.getElementById('ipKhoaid').value = username;
                    document.getElementById('ipKhoaName').value = account.tenTaiKhoan;
                    document.getElementById('ipKhoaEmail').value = account.email;
                    document.getElementById('ipKhoaQuyen').value = account.vaiTro;
                    if (account.trangThai === 2) {
                        document.getElementById('modalKhoaTKTitle').innerHTML = "Bạn muốn khóa tài khoản này?";
                        document.getElementById('btnKhoaTK').innerHTML = "Khóa";
                    } else if (account.trangThai === 3) {
                        document.getElementById('modalKhoaTKTitle').innerHTML = "Bạn muốn mở khóa tài khoản này?";
                        document.getElementById('btnKhoaTK').innerHTML = "Mở khóa";
                    }
                } else {
                    showToast("warning", data.message);
                }
            })
            .catch(error => {
                showToast("error", "Có lỗi xảy ra khi tải dữ liệu, vui lòng thử lại!");
            });
        });
    });

    document.getElementById("formKhoaTK").addEventListener("submit", function (e) {
        e.preventDefault(); // Ngăn form load lại trang

        let username = document.getElementById("ipKhoaid").value;

        fetch("/QLyTaiKhoan/KhoaTaiKhoan", {
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded"
            },
            body: new URLSearchParams({ ipKhoaid: username })
        })
        .then(response => response.json())
        .then(data => {
            showToast(data.success ? "success" : "warning", data.message);
            if (data.success) {
                location.reload(); // Reload trang sau khi khóa/mở khóa thành công
            }
        })
        .catch(error => {
            showToast("error", "Có lỗi xảy ra, vui lòng thử lại!");
        });
    });

});


function filterTable() {
    let input = document.getElementById("searchInput");
    let filter = input.value.toLowerCase();
    let table = document.getElementById("accountTable");
    let rows = table.getElementsByTagName("tr");

    for (let i = 0; i < rows.length; i++) {
        let cells = rows[i].getElementsByTagName("td");
        if (cells.length > 1) {
            let accountName = cells[1].textContent || cells[1].innerText;
            if (accountName.toLowerCase().indexOf(filter) > -1) {
                rows[i].style.display = "";
            } else {
                rows[i].style.display = "none";
            }
        }
    }
}

