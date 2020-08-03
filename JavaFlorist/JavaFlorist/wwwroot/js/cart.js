$(document).ready(function () {
    $(".cart-list input[name='quantity']").TouchSpin({
        min: 1,
        initval: 1
    });
    // update_current_addres_shipping();
    validate_ship();

    var dist_name = localStorage.getItem("dist_name");
    var district_name = '';
    if (dist_name) {
        localStorage.clear();
    }
    district_name = $('#d_name').data('dist');
    var city_name = $('.current-address').data('city');
    var address = district_name + ', ' + city_name;
    $('.current-address').html(address);
})

function validate_ship(){
    $("#checkoutform").validate({
        ignore: null,
        ignore: 'input[type="hidden"]',
        rules: {
            fullname: {
                required: true
            },
            address_type_id: {
                required: true
            },
            city_id: {
                required: true
            },
            ship_district: {
                required: true
            },
            ship_ward: {
                required: true
            },
            ship_address: {
                required: true
            },
            customer_phone: {
                required: true
            }
        },
        messages: {
            fullname: {
                required: "Vui lòng điền tên người nhận!"
            },
            address_type_id: {
                required: "Vui lòng chọn loại địa chỉ!"
            },
            city_id: {
                required: "Vui lòng chọn Tỉnh/Thành Phố!"
            },
            ship_district: {
                required: "Vui lòng chọn Quận/Huyện!"
            },
            ship_ward: {
                required: "Vui lòng chọn Phường/Xã!"
            },
            ship_address: {
                required: "Vui lòng nhập địa chỉ cho nhân viên giao hàng!"
            },
            customer_phone: {
                required: "Vui lòng nhập số điện thoại người nhận!"
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });
}

function validate_store(){
    $("#checkoutform").validate({
        ignore: null,
        ignore: 'input[type="hidden"]',
        rules: {
            Name: {
                required: true
            },
            Phone: {
                required: true
            },
            email: {
                required: true
            },
        },
        messages: {
            Name: {
                required: "Vui lòng điền tên người mua hàng!"
            },
            Phone: {
                required: "Vui lòng điền Sdt người mua hàng!"
            },
            email: {
                required: "Vui lòng điền email người mua hàng!"
            },
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });
}

//load cart in header
function get_cart() {
    $.ajax({
        url: root_url + "/shopcart/get_cart",
        type: "POST",
        dataType: "html",
        context: $(this),
        success: function (result) {
            $('#cart').html(result);
            get_total_num_cart();
        }
    });
}

//load detail cart
function get_cart_page() {
    $.ajax({
        url: root_url + "/shopcart/get_cart_page",
        type: "POST",
        dataType: "html",
        context: $(this),
        success: function (result) {
            $('#cart-page').html(result);
            $(".cart-list input[name='quantity']").TouchSpin({
                min: 1,
                initval: 1
            });
            $('.selectpicker').selectpicker();
            //get new data for delivery-box
            if (document.getElementById("delivery-box")) {
                check_cost_delivery();
            }
            get_total_num_cart();
            // update_current_addres_shipping();
        }
    });
}

//load detail cart summary
function get_cart_summary() {
    $.ajax({
        url: root_url + "/shopcart/get_cart_summary",
        type: "POST",
        dataType: "html",
        data: {
            "wardID": $('#ward-select').val(),
            "districtID": $('#district-select').val(),
        },
        context: $(this),
        success: function (result) {
            $('#cart-summary').html(result);
        }
    });
}

function add_mult_cart() {
    var str = ''
    $('input[name^="bundle_item_id"]').each(function () {
        var id = $(this).val();
        str += id;
        str += ',' + $('input[name="bundle_item_qty' + id + '"]').val();
        str += ',packing_item|';
    });
    var url = window.location.origin + "/shopcart/addcart?ids=" + str;
    window.location.href = url;
}

function get_total_num_cart() {
    //ajax update giỏ hàng
    $.ajax({
        url: root_url + "/shopcart/get_total_cart",
        type: "GET",
        dataType: "json",
        context: $(this),
        success: function (result) {
            if (result.error) {
                alert(result.message);
            } else {
                $('#cart-num').html(result.total);
            }
            //console.log(result);
        }
    });
}

function remove_cart(object) {

    var suggest = 0;
    var id = $(object).data("id");
    var price = $(object).data("price"); // for GA
    var fly = $(object).data("fly");

    var unit = $(object).data("unit");
    if (typeof unit == "undefined" || unit == '' || unit == 0) {
        unit = $("#choiceunit option:selected").val();
        if (typeof unit == "undefined" || unit == '' || unit == 0) {
            unit = 'packing_item';
        }
    }

    //ajax update giỏ hàng
    $.ajax({
        url: root_url + "/shopcart/add_cart",
        type: "POST",
        dataType: "json",
        data: { product_id: id, unit: unit, quantity: 0, suggest: suggest },
        context: $(this),
        beforeSend: function () {
            $('.body-loading').addClass('show');
        },
        success: function (result) {
            $('.body-loading').removeClass('show');
            if (result.error) {
                alert(result.message);
            } else {
                if (document.getElementById("cart")) {
                    get_cart();
                }
                if (document.getElementById("cart-page")) {
                    get_cart_page();
                }
            }
            //console.log(result);
        }
    });
}

//button add to cart
function add_cart(object, type_direct) {

    var suggest = 0;
    var id = $(object).data("id");
    var price = $(object).data("price"); // for GA
    var fly = $(object).data("fly");

    var unit = $(object).data("unit");
    if (typeof unit == "undefined" || unit == '' || unit == 0) {
        unit = $("#choiceunit option:selected").val();
        if (typeof unit == "undefined" || unit == '' || unit == 0) {
            unit = 'packing_item';
        }
    }

    var quantity = $(object).data("quantity");
    if (typeof quantity == "undefined" || quantity == '' || quantity == 0) {
        var quantity = $("#quantity").val();
        suggest = 1;
    }

    if (typeof quantity == "undefined" || quantity == '' || quantity == 0) {
        quantity = 1;
    }

    if (quantity % 1 !== 0) {
        alert('Số lượng không hợp lệ');
        return false;
    }

    var type = $(object).data("type");

    var total_item = 0;

    if (id > 0) {

        if (typeof type != "undefined" && type == 'plus') {
            $(object).addClass('hidden');
            var qty_obj = $(object).parent().find('.btn-qty').eq(0);
            qty_obj.removeClass('hidden');
            var itemImg = $(object).parent().parent().find('img').eq(0);
            if (fly == '1') {
                flyToCart($(itemImg), $('.cart-button'));
            }
        }

        if (typeof type != "undefined" && type == 'add') {
            var input_obj = $(object).parent().find('input').eq(0);
            var current_qty = parseInt(input_obj.val()) + 1;
            if (current_qty < 99) {
                var itemImg = $(object).parent().parent().parent().find('img').eq(0);
                if (fly == '1') {
                    flyToCart($(itemImg), $('.cart-button'));
                }
                input_obj.val(current_qty);
            }
        }

        if (typeof type != "undefined" && type == 'substract') {
            var input_obj = $(object).parent().find('input').eq(0);
            var current_qty = parseInt(input_obj.val()) - 1;
            if (current_qty > 0) {
                var itemImg = $(object).parent().parent().parent().find('img').eq(0);
                if (fly == '1') {
                    cartFly($('.cart-button'), $(itemImg), itemImg);
                }
                input_obj.val(current_qty);
            } else {
                var qty_obj = $(object).parent().parent().find('.btn-qty').eq(0);
                qty_obj.addClass('hidden');
                var btn_cart_obj = $(object).parent().parent().find('.btn-addcart').eq(0);
                btn_cart_obj.removeClass('hidden');
                remove_product(object);
                return false;
            }
        }

        //ajax update giỏ hàng
        $.ajax({
            url: root_url + "/shopcart/add_cart",
            type: "POST",
            dataType: "json",
            data: { product_id: id, unit: unit, quantity: quantity, suggest: suggest },
            context: $(this),
            beforeSend: function () {
                $('.body-loading').addClass('show');
            },
            success: function (result) {
                $('.body-loading').removeClass('show');
                if (result.error) {
                    alert(result.message);
                } else {
                    if (result.current_item) {
                        $(object).parent().find('input[name="item-quality"]').eq(0).val(result.current_item);
                    }
                    if (document.getElementById("cart")) {
                        get_cart();
                    }
                    if (document.getElementById("cart-page")) {
                        get_cart_page();
                    }
                    if (result.suggest != '') {
                        // document.location.href = root_url + '/shopcart/gio-hang.html';
                        if (type_direct == 1) {
                            $('#suggest_list').html(result.suggest);
                            $('.toggle-popupCart').trigger('click');
                            get_total_num_cart();
                        } else {
                            document.location.href = root_url + '/shopcart/gio-hang.html';
                        }
                    }
                }
            }
        });

        if (typeof dataLayer != "undefined" && typeof price != "undefined") {
            dataLayer.push({
                'event': 'Event_AddToCart',
                'remarketing_data': {
                    'dynx_itemid': ['\'+id+\''],
                    'dynx_totalvalue': price,
                }
            });
        }

    }
}

// function change_qty(object){
//     console.log($(object).val());
//     var current_qty = $(object).val();
//     var item_current_qty = $(object).parent().parent().find('input[name="item_qty_current"]').eq(0).val();
//     // var btn_obj =  $(object).parent().find('.btn-add').eq(0);
//     // var btn_update_obj =  $(object).parent().find('.btn-update').eq(0);
//     // console.log(current_qty);
//     // console.log(item_current_qty);
//     //
//     // if(type=='blur' && current_qty==item_current_qty){
//     //     btn_obj.removeClass('hidden');
//     //     btn_update_obj.addClass('hidden');
//     //     $(object).parent().find('.btn-substract').eq(0).prop('disabled', false);
//     // }else if(type=='focus'){
//     //     btn_obj.addClass('hidden');
//     //     btn_update_obj.removeClass('hidden');
//     //     $(object).parent().find('.btn-substract').eq(0).prop('disabled', true);
//     // }
// }

function update_qty_product(object) {
    var quantity = parseInt($(object).val());

    var id = $(object).data("id");
    var unit = $(object).data("unit");

    if (id > 0) {
        //ajax update giỏ hàng
        $.ajax({
            url: root_url + "/shopcart/add_cart",
            type: "POST",
            dataType: "json",
            data: { product_id: id, quantity: quantity, unit: unit, action: "update" },
            context: $(object),
            success: function (result) {
                if (result.error) {
                    alert(result.message);
                } else {
                    // if (document.getElementById("cart")) {
                    //     get_cart();
                    // }
                    if (document.getElementById("cart-page")) {
                        get_cart_page();
                    }
                    // Note: *** At checkout.html if change quality is reload page;
                    if (document.getElementById("checkout-summary")) {
                        location.reload(); //document.location.href = '/shopcart/gio-hang.html';
                    }
                }
                //console.log(result);
            }
        });

    }
}

function get_ward_shipping(data) {
    var district_id = data.value;
    var city_id = $('#city_id').val();
    $.cookie('district_id_' + city_id, district_id, { expires: 180, path: '/' });
    $('#ward-select').prop("disabled", true);
    $.ajax({
        url: root_url + "/auchan/ajax/GetWard",
        type: "POST",
        dataType: "html",
        data: { district_id: district_id },
        context: $(this),
        success: function (result) {
            if (result) {
                $('#ward-select').html(result);
                $('#ward-select').prop("disabled", false);
                $('.selectpicker').selectpicker("refresh");
                var district_name = $('#district-select option[value=' + $('#district-select').val() + ']').html();
                localStorage.setItem("dist_name", district_name);
                update_current_addres_shipping();
            }
        }
    });
}

function update_current_addres_shipping() {

    var dist_name = localStorage.getItem("dist_name");
    var district_name = '';
    if (dist_name) {
        district_name = dist_name;
    } else {
        district_name = $('#district-select option[value=' + $('#district-select').val() + ']').html();
        localStorage.setItem("dist_name", district_name);
    }
    var ward_name = '';
    if ($('#ward-select').val())
        ward_name = $('#ward-select option[value=' + $('#ward-select').val() + ']').html();
    var address = '';
    var city_name = $('.current-address').data('city');
    if (city_name) address = city_name;
    if (district_name) address = district_name + ', ' + address;
    if (ward_name) address = ward_name + ', ' + address;

    $('.current-address').html(address);
}


function get_delivery(data) {
    var ward_id = data.value;
    $.cookie('ward_id', ward_id, { expires: 180, path: '/' });

    //backup info
    // $.cookie('checkout_address', $('#checkout-address').val(), { expires: 1, path: '/' });
    // $.cookie('checkout_fullname', $('#checkout-fullname').val(), { expires: 1, path: '/' });
    // $.cookie('checkout_email', $('#checkout-email').val(), { expires: 1, path: '/' });
    // $.cookie('checkout_phone', $('#checkout-phone').val(), { expires: 1, path: '/' });
    // $.cookie('checkout_phone2', $('#checkout-phone2').val(), { expires: 1, path: '/' });
    // $.cookie('checkout_note', $('#checkout-note').val(), { expires: 1, path: '/' });
    // $.cookie('reload', 'checkoutform', { expires: 1, path: '/' });
    if (document.getElementById("cart")) {
        get_cart();
    }
    if (document.getElementById("cart-page")) {
        get_cart_page();
    }

    if (document.getElementById("cart-summary")) {
        get_cart_summary();
    }
}


function coupon(obj) {
    var coupon = $("#coupon").val();
    $('#coupon_error').html('');
    $.ajax({
        url: root_url + "/shopcart/coupon",
        type: "POST",
        dataType: "json",
        data: { action: 'CouponCode', coupon: coupon },
        context: $(this),
        success: function (result) {
            if (result.error == false) {
                if (result.require == 'customer') {
                    //$('#signupModal').modal('show');
                }
                $('#coupon_info').html(result.msg);
            } else {
                $('#coupon_error').html(result.msg);
            }
            //console.log(result);
        }
    });
    return false;
}


function address_book(id, current_id, return_url) {
    $.ajax({
        url: "auchan/ajax/AddressBook",
        type: "POST",
        dataType: "html",
        data: { id: id, current_id: current_id, return_url: return_url },
        context: $(this),
        success: function (result) {
            if (result) {
                $('#address_book').html(result);
            }
        }
    });

}

function choice_address(address_id, city_id, district_id, ward_id) {
    $.cookie('district_id_' + city_id, district_id, { expires: 18000, path: '/' });
    $.cookie('ward_id', ward_id, { expires: 18000, path: '/' });
    $.cookie('address_id', address_id, { expires: 18000, path: '/' });
    location.reload();
}

function check_vat(id) {
    var vat = $('input[name=vat_check]:checked').val();
    if (vat == 1) {
        $('#' + id).show('slow');
    } else {
        $('#' + id).hide('slow');
    }
}

function yesnoCheck() {
    if (document.getElementById('yesCheck').checked) {
        document.getElementById('ifYes').value = 5;
    } else {
        document.getElementById('ifYes').value = 0;
    }
}


