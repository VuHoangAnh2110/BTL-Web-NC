document.addEventListener('DOMContentLoaded', function() {
    const logoUpload = document.getElementById('logo-upload');
    const logoPreview = document.getElementById('logo-preview-img');
    const uploadButton = document.getElementById('upload-button');
    const logoPreviewDiv = document.querySelector('.logo-preview');
    const overlayText = document.querySelector('.overlay-text');
    
    // Hiển thị overlay text khi hover vào logo
    logoPreviewDiv.addEventListener('mouseenter', function() {
        overlayText.style.display = 'block';
    });
    
    logoPreviewDiv.addEventListener('mouseleave', function() {
        overlayText.style.display = 'none';
    });
    
    // Xử lý click vào logo để chọn file
    logoPreviewDiv.addEventListener('click', function() {
        logoUpload.click();
    });
    
    uploadButton.addEventListener('click', function() {
        logoUpload.click();
    });
    
    // Preview logo khi chọn file
    logoUpload.addEventListener('change', function() {
        if (this.files && this.files[0]) {
            const reader = new FileReader();
            
            reader.onload = function(e) {
                logoPreview.src = e.target.result;
            }
            
            reader.readAsDataURL(this.files[0]);
        }
    });

    // Xóa thông báo lỗi khi người dùng thay đổi giá trị
    document.querySelectorAll('input, textarea').forEach(el => {
        el.addEventListener('input', function() {
            // Xóa trạng thái lỗi
            this.classList.remove('is-invalid');
            
            // Tìm thẻ span validation tương ứng và xóa nội dung
            const fieldName = this.getAttribute('name');
            const validationSpan = document.querySelector(`span[asp-validation-for="${fieldName}"]`);
            const dataSpan = document.querySelector(`span[data-valmsg-for="${fieldName}"]`);
            if (validationSpan) {
                validationSpan.textContent = '';
            } else if (dataSpan) {
                dataSpan.textContent = '';
            }

            
            // Xóa cảnh báo chung nếu có
            const alertDiv = document.querySelector('.alert-danger');
            if (alertDiv) {
                alertDiv.remove();
            }
        });
    });

    // Form validation
    const editForm = document.getElementById('editForm');
    editForm.addEventListener('submit', function(event) {
        let isValid = true;
        
        // Reset tất cả thông báo lỗi
        document.querySelectorAll('span[data-valmsg-for], span[asp-validation-for]').forEach(el => {
            el.textContent = '';
        });
        document.querySelectorAll('.is-invalid').forEach(el => {
            el.classList.remove('is-invalid');
        });
        
        // Kiểm tra Tên công ty (bắt buộc)
        const tenCongTy = document.querySelector('input[name="TenCongTy"]');
        if (!tenCongTy.value.trim()) {
            isValid = false;
            tenCongTy.classList.add('is-invalid');
            document.querySelector('span[data-valmsg-for="TenCongTy"]') ? 
                        document.querySelector('span[data-valmsg-for="TenCongTy"]').textContent = 'Vui lòng nhập tên công ty' :
                        document.querySelector('span[asp-validation-for="TenCongTy"]').textContent = 'Vui lòng nhập tên công ty';
        }
        
        // Kiểm tra Địa chỉ công ty (bắt buộc)
        const diaChi = document.querySelector('input[name="DiaChi"]');
        if (!diaChi.value.trim()) {
            isValid = false;
            diaChi.classList.add('is-invalid');
            document.querySelector('span[data-valmsg-for="DiaChi"]') ? 
                        document.querySelector('span[data-valmsg-for="DiaChi"]').textContent = 'Vui lòng nhập địa chỉ công ty' :
                        document.querySelector('span[asp-validation-for="DiaChi"]').textContent = 'Vui lòng nhập địa chỉ công ty';
        }
        
        // Kiểm tra Mô tả công ty (bắt buộc)
        const moTa = document.querySelector('textarea[name="MoTa"]');
        if (!moTa.value.trim()) {
            isValid = false;
            moTa.classList.add('is-invalid');
            document.querySelector('span[data-valmsg-for="MoTa"]') ? 
                        document.querySelector('span[data-valmsg-for="MoTa"]').textContent = 'Vui lòng nhập mô tả công ty' :
                        document.querySelector('span[asp-validation-for="MoTa"]').textContent = 'Vui lòng nhập mô tả công ty';
        }
        
        // Kiểm tra Số điện thoại (định dạng)
        const soDienThoai = document.querySelector('input[name="SoDienThoai"]');
        if (soDienThoai.value.trim() && !/^[0-9]{10,11}$/.test(soDienThoai.value.trim())) {
            isValid = false;
            soDienThoai.classList.add('is-invalid');
            document.querySelector('span[data-valmsg-for="SoDienThoai"]') ? 
                        document.querySelector('span[data-valmsg-for="SoDienThoai"]').textContent = 'Số điện thoại phải có 10-11 chữ số' :
                        document.querySelector('span[asp-validation-for="SoDienThoai"]').textContent = 'Số điện thoại phải có 10-11 chữ số';
        }
        
        // // Kiểm tra LogoFile (nếu có)
        // const logoFile = document.getElementById('logo-upload');
        // if (logoFile.files.length > 0) {
        //     const file = logoFile.files[0];
            
        //     // Kiểm tra kích thước (tối đa 5MB)
        //     if (file.size > 5 * 1024 * 1024) {
        //         isValid = false;
        //         const logoErrorMessage = 'Kích thước file không được vượt quá 5MB';
                
        //         // Hiển thị lỗi dưới nút upload
        //         const uploadButton = document.getElementById('upload-button');
        //         let errorSpan = uploadButton.nextElementSibling;
                
        //         if (!errorSpan || !errorSpan.classList.contains('text-danger')) {
        //             errorSpan = document.createElement('div');
        //             errorSpan.className = 'text-danger mt-2';
        //             uploadButton.parentNode.insertBefore(errorSpan, uploadButton.nextSibling);
        //         }
        //         errorSpan.textContent = logoErrorMessage;
        //     }
            
        //     // Kiểm tra định dạng file
        //     const allowedExtensions = ['.jpg', '.jpeg', '.png', '.gif'];
        //     const fileExtension = file.name.substring(file.name.lastIndexOf('.')).toLowerCase();
        //     if (!allowedExtensions.includes(fileExtension)) {
        //         isValid = false;
        //         const logoErrorMessage = 'Chỉ chấp nhận file hình ảnh (jpg, jpeg, png, gif)';
                
        //         // Hiển thị lỗi dưới nút upload
        //         const uploadButton = document.getElementById('upload-button');
        //         let errorSpan = uploadButton.nextElementSibling;
                
        //         if (!errorSpan || !errorSpan.classList.contains('text-danger')) {
        //             errorSpan = document.createElement('div');
        //             errorSpan.className = 'text-danger mt-2';
        //             uploadButton.parentNode.insertBefore(errorSpan, uploadButton.nextSibling);
        //         }
        //         errorSpan.textContent = logoErrorMessage;
        //     }
        // }
        
        if (!isValid) {
            event.preventDefault();
            // Cuộn đến phần tử lỗi đầu tiên
            const firstInvalidElement = document.querySelector('.is-invalid');
            if (firstInvalidElement) {
                firstInvalidElement.scrollIntoView({ behavior: 'smooth', block: 'center' });
                firstInvalidElement.focus();
            }
        }
    });


    console.log("Edit employer page loaded!");
});