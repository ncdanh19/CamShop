var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    // .append('<div> <div class=row>' + '<a>' + '<img + src = ' + item.hinhAnh + ' style = width:10%;height:10%>' + item.tenSanPham + '</br>' + item.donGia + '</a>' + '</div> </div>')
                    .append('<div class=row>' +
                        '<div class=col-sm-3>' +
                        '<a href=/san-pham/chi-tiet/' + item.MetaTitle + '-' + item.sanPhamID + '>' +
                        '<img src = ' + item.hinhAnh + ' style = width:100%>' +
                        '</a>' +
                        '</div>' +
                        '<div class=col-sm-9>' +
                        '<a href=/san-pham/chi-tiet/' + item.MetaTitle + '-' + item.sanPhamID + '>' +
                        '<p>' + item.tenSanPham + '</p>' +
                        '<p>' + item.donGia + '<label>đ</label>' + '</p>' +
                        '</a>' +
                        '</div>' +
                        '</div>')

                    .appendTo(ul);

            };
    }
}
common.init();