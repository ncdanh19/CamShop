﻿var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        //Button tiếp tục mua hàng
        $('.continue').off('click').on('click', function () {
            window.location.href = "/";
        });
       
        //Update số lượng sản phẩm
        $('#Quantity').on('change', function () {                  
            var listProduct = $('#Quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    SanPham: {
                        sanPhamID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: 'cart-update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });        

        //Xóa sản phẩm (chưa xong 30:00)
        $('.close1').on('change', function () {           
            $.ajax({
                url: 'cart-update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });        

    }
}
cart.init();