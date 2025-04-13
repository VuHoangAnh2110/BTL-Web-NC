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

    function capNhatTrangThai(maUngTuyen, trangThai) {
        // Lưu tham chiếu đến hàng chứa ứng tuyển
        let row = $(`button[onclick*="${maUngTuyen}"]`).closest('tr');
        
        // Thêm hiệu ứng đang xử lý
        let cotTrangThai = row.find('td:nth-child(6)');
        let TrangThaiCu = cotTrangThai.html();
        cotTrangThai.html(`<div class="spinner-border spinner-border-sm text-primary" role="status">
                            <span class="visually-hidden">Đang xử lý...</span>
                        </div>`);
        
        // Vô hiệu hóa các nút trong hàng này
        //let actionButtons = row.find('button');
        //actionButtons.prop('disabled', true);
        let actionButtonCell = row.find('td:last-child').find('button');
        actionButtonCell.prop('disabled', true)
        
        $.ajax({
            url: '/Job/CapNhatTrangThaiUngTuyen',
            type: 'POST',
            data: {
                maUngTuyen: maUngTuyen,
                trangThai: trangThai
            },
            success: function(response) {
                if (response.success) {
                    // Cập nhật trạng thái hiển thị
                    let badgeClass = trangThai === 'Chấp nhận' ? 'bg-success' : 'bg-danger';
                    cotTrangThai.html(`<span class="badge ${badgeClass}">${trangThai}</span>`);
                    
                    // Cập nhật nút thao tác
                    let actionCell = row.find('td:last-child')
                    if (trangThai === 'Chấp nhận') {
                        actionCell.html(`
                        <div class="btn-group">
                            <button class="btn btn-sm btn-outline-secondary" disabled>
                                <i class="bi bi-check-circle-fill text-success me-1"></i>Đã duyệt
                            </button>
                        </div>
                    `);
                } else if (trangThai === 'Từ chối') {
                    actionCell.html(`
                        <div class="btn-group">
                            <button class="btn btn-sm btn-outline-secondary" disabled>
                                <i class="bi bi-x-circle-fill text-danger me-1"></i>Đã duyệt 
                            </button>
                        </div>
                    `);
                }
                
                // Hiển thị thông báo thành công
                showToast("success", "Duyệt hồ sơ thành công!")
                
                // Hiệu ứng highlight cho hàng vừa cập nhật
                row.addClass('table-success');
                setTimeout(function() {
                    row.removeClass('table-success');
                }, 2000);
            } else {
                // Khôi phục trạng thái cũ nếu có lỗi
                cotTrangThai.html(TrangThaiCu);
                actionButtonCell.prop('disabled', false);
                
                // Hiển thị thông báo lỗi
                showToast("warning", "Duyệt hồ sơ không thành công!")
            }
        },
        error: function() {
            // Khôi phục trạng thái cũ nếu có lỗi
            cotTrangThai.html(TrangThaiCu);
            actionButtonCell.prop('disabled', false);
            
            // Hiển thị thông báo lỗi
            showToast("error", "Có lỗi khi duyệt hồ sơ!")
        }
    });
}

    function xemCV(tenTaiKhoan, maCongViec) {
        var modal = new bootstrap.Modal(document.getElementById('cvModal'));
        modal.show();
        
        // Cập nhật nút tải xuống CV
        document.getElementById('downloadCvBtn').href = `/Job/DownloadCV?tenTaiKhoan=${tenTaiKhoan}&maCongViec=${maCongViec}`;
        
        // Hiển thị trạng thái loading
        document.getElementById('cvModalBody').innerHTML = `
            <div class="text-center">
                <div class="spinner-border" role="status">
                    <span class="visually-hidden">Đang tải...</span>
                </div>
            </div>`;
        
        // Gửi yêu cầu lấy thông tin CV sử dụng fetch API
        fetch(`/Job/XemCV?tenTaiKhoan=${encodeURIComponent(tenTaiKhoan)}&maCongViec=${encodeURIComponent(maCongViec)}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Lỗi kết nối');
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {
                    var fileUrl = data.fileUrl;
                    var fileExtension = fileUrl.split('.').pop().toLowerCase();
                    
                    if (fileExtension === 'pdf') {
                        // Hiển thị PDF trong iframe
                        document.getElementById('cvModalBody').innerHTML = `<iframe src="${fileUrl}" width="100%" height="400px"></iframe>`;
                    } else if (['jpg', 'jpeg', 'png'].includes(fileExtension)) {
                        // Hiển thị hình ảnh
                        document.getElementById('cvModalBody').innerHTML = `<img src="${fileUrl}" class="img-fluid" />`;
                    } else {
                        // Với các file khác, hiển thị link tải xuống
                        document.getElementById('cvModalBody').innerHTML = `
                            <div class="text-center">
                                <i class="bi bi-file-earmark-text display-1 text-primary"></i>
                                <p class="mt-3">CV của ứng viên không thể hiển thị trực tiếp.</p>
                                <p>Vui lòng tải xuống để xem.</p>
                            </div>`;
                    }
                } else {
                    document.getElementById('cvModalBody').innerHTML = `
                        <div class="alert alert-warning">
                            <i class="bi bi-exclamation-triangle me-2"></i>
                            Không tìm thấy CV của ứng viên này.
                        </div>`;
                }
            })
            .catch(error => {
                console.error('Lỗi:', error);
                document.getElementById('cvModalBody').innerHTML = `
                    <div class="alert alert-danger">
                        <i class="bi bi-x-circle me-2"></i>
                        Đã xảy ra lỗi khi tải CV. Vui lòng thử lại sau.
                    </div>`;
            });
    }

$(document).ready(function() {
    

    $("#searchInput").on("keyup", function() {
        var value = $(this).val().toLowerCase();
        $("table tbody tr").filter(function() {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });





});