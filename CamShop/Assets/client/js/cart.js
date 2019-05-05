var cart = {
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

        //Xóa sản phẩm trong giỏ hàng
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: 'Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('.close1').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: 'Cart/Delete',
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