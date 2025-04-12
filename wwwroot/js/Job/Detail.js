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

function submitApplication() {
    let cvFile = document.getElementById('cvUpload').files[0];
    let cvFileInput = document.getElementById('cvUpload');
    cvFileInput.classList.remove('is-invalid');

    if (!cvFile) {
        showToast('warning', 'Vui lòng tải lên CV của bạn.');
        cvFileInput.classList.add('is-invalid');
        return;
    }

    // Kiểm tra kích thước file (tối đa 5MB)
    if (cvFile.size > 5 * 1024 * 1024) {
        showToast('warning', 'Kích thước file quá lớn. Vui lòng tải lên file có dung lượng nhỏ hơn 5MB.');
        cvFileInput.classList.add('is-invalid');
        return;
    }

    let formData = new FormData();
    // formData.append('maCongViec', '@Model.MaCongViec');
    formData.append('maCongViec', document.getElementById('maCongViec').value);
    formData.append('cv', cvFile);

    // Hiển thị trạng thái đang xử lý
    document.querySelector('.modal-footer button:last-child').innerHTML = '<span class="spinner-border spinner-border-sm me-2"></span>Đang xử lý...';
    document.querySelector('.modal-footer button:last-child').disabled = true;

    fetch('/Application/ApplyJob', {
        method: 'POST',
        body: formData
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            showToast('success', 'Nộp hồ sơ thành công! Hãy chờ email liên hệ từ nhà tuyển dụng.');
            // Đóng modal
            bootstrap.Modal.getInstance(document.getElementById('applyModal')).hide();
        } else {
            cvFileInput.classList.add('is-invalid');
            showToast('warning', data.message);
        }
    })
    .catch(error => {
        console.error('Lỗi:', error);
        showToast('error', 'Đã xảy ra lỗi khi xử lý yêu cầu của bạn.');
    })
    .finally(() => {
        // Khôi phục trạng thái nút
        document.querySelector('.modal-footer button:last-child').innerHTML = '<i class="bi bi-send me-1"></i>Nộp hồ sơ';
        document.querySelector('.modal-footer button:last-child').disabled = false;
    });
}

document.addEventListener("DOMContentLoaded", function () {
    
});