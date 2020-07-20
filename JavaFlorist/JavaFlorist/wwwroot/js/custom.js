var isMobile = false; //initiate as false
// device detection
if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
    || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
    isMobile = true;
}
jQuery(document).ready(function () {
    $(document).on('click', '#resetpassword1', function () {
        var phone = $('input[name=user_resetpassword_phone]').val();
        if (check_valid_phone_new(phone)) {
            $.ajax({
                url: root_url + "/member/resetpassword.html",
                dataType: "json",
                type: "POST",
                data: { username: phone, action: 'resetpassword1' },
                context: $(this),
                success: function (result) {

                    if (result.error == false) {
                        $('#fogotPasswordModal .resetpass_msg_2').html(result.msg);
                        $('#fogotPasswordModal .step-1').addClass('hidden');
                        $('#fogotPasswordModal .step-2').removeClass('hidden');
                    } else {
                        $('#fogotPasswordModal .resetpass_msg_1').html(result.msg);
                    }
                }
            });
        } else {
            alert("Số điện thoại không hợp lệ");
        }
    });

    $(document).on('click', '#resetpassword2', function () {
        var phone = $('input[name=user_resetpassword_phone]').val();
        var otp = $('input[name=user_resetpassword_otp]').val();
        if (otp != '') {
            $.ajax({
                url: root_url + "/member/resetpassword.html",
                dataType: "json",
                type: "POST",
                data: { username: phone, action: 'resetpassword2', otp: otp },
                context: $(this),
                success: function (result) {
                    if (result.error == false) {
                        if (result.hash != '') {

                            $('input[name=resetpwd_hash]').val(result.hash);
                            $('#fogotPasswordModal .step-1').addClass('hidden');
                            $('#fogotPasswordModal .step-2').addClass('hidden');
                            $('#fogotPasswordModal .step-3').removeClass('hidden');
                        }

                    } else {
                        $('#fogotPasswordModal .resetpass_msg_2').html(result.msg);
                        $('#fogotPasswordModal .resetpass_msg_3').html('');
                    }
                }
            });
        } else {
            alert("Vui lòng nhập mã xác nhận trước !");
        }
    });

    $(document).on('click', '#resetpassword3', function () {
        var phone = $('input[name=user_resetpassword_phone]').val();
        var password = $('input[name=reset_password]').val();
        var password2 = $('input[name=reset_password2]').val();
        var resetpwd_hash = $('input[name=resetpwd_hash]').val();
        if (password == password2) {
            $.ajax({
                url: root_url + "/member/resetpassword.html",
                dataType: "json",
                type: "POST",
                data: { action: 'resetpassword3', password: password, password2: password2, username: phone, resetpwd_hash: resetpwd_hash },
                context: $(this),
                success: function (result) {
                    document.location.href = '/member/userinfo.html';
                }
            });
        } else {
            alert('Nhập lại mật khẩu không giống');
        }

    });

    jQuery('.grid').masonry({
        columnWidth: '.grid-sizer',
        itemSelector: '.grid-item',
        gutter: '.gutter-sizer',
        percentPosition: true
    });

    // Begin product detail slider
    if (jQuery('.detail-slider').length) {
        var $slider = jQuery('.detail-slider')
            .on('init', function (slick) {
                jQuery('.detail-slider').fadeIn(1000);
            })
            .slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                arrows: false,
                lazyLoad: 'ondemand',
                asNavFor: '.slider-nav-thumbnails'
            });

        var $slider2 = jQuery('.slider-nav-thumbnails')
            .on('init', function (slick) {
                jQuery('.slider-nav-thumbnails').fadeIn(1000);
            })
            .slick({
                slidesToShow: 3,
                slidesToScroll: 1,
                lazyLoad: 'ondemand',
                asNavFor: '.detail-slider',
                dots: false,
                arrows: false,
                centerMode: false,
                focusOnSelect: true
            });

        //remove active class from all thumbnail slides
        jQuery('.slider-nav-thumbnails .slick-slide').removeClass('slick-active');

        //set active class to first thumbnail slides
        jQuery('.slider-nav-thumbnails .slick-slide').eq(0).addClass('slick-active');

        // On before slide change match active thumbnail to current slide
        jQuery('.detail-slider').on('beforeChange', function (event, slick, currentSlide, nextSlide) {
            var mySlideNumber = nextSlide;
            jQuery('.slider-nav-thumbnails .slick-slide').removeClass('slick-active');
            jQuery('.slider-nav-thumbnails .slick-slide').eq(mySlideNumber).addClass('slick-active');
        });



    }
    // End product detail slider
    $(".product-info input[name='quantity']").TouchSpin({
        initval: 40
    });
    if ($('.selectpicker').length) {
        $('.selectpicker').selectpicker();
    }

    $('.decor-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        prevArrow: '<img class="slick-prev" src="' + theme_url + '/images/prev.png" />',
        nextArrow: '<img class="slick-next" src="' + theme_url + '/images/next.png" />',
    });
    $('.blog-slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        prevArrow: '<img class="slick-prev" src="' + theme_url + '/images/prev.png" />',
        nextArrow: '<img class="slick-next" src="' + theme_url + '/images/next.png" />',
    });

    // $("[name=delivery_type]").click(function () {
    //     $('.home-delivery').hide('slow');
    //     $("#blk-" + $(this).val()).show('slow');
    // });
    $("[name=receive_type]").click(function () {
        $('.home-delivery').hide('slow');
        $("#blk-" + $(this).val()).show('slow');

        if ($(this).val() == 'store') {
            $('.shipping_price').hide();
            $('p .have_ship').addClass('hidden');
            $('p .no_ship').removeClass('hidden');
            $('#checkoutform').removeData('validator');
            validate_store();
        } else {
            $('p .have_ship').removeClass('hidden');
            $('p .no_ship').addClass('hidden');
            $('.shipping_price').show();
            $('#checkoutform').removeData('validator');
            validate_ship();
        }
    });

    $("[name=delivery_type]").click(function () {
        $('.time-delivery').hide('slow');
        $("#time-" + $(this).val()).show('slow');
    });



    $("input[name=payment]").click(function () {
        console.log($(this).val());
        if ($(this).val() == 'cod') {
            $('button[name=cod]').removeClass('hidden');
            $('button[name=paymentvisa]').addClass('hidden');
            $('button[name=paymentatm]').addClass('hidden');
        }
        if ($(this).val() == 'onepay_visa') {
            console.log('asd');
            $('button[name=cod]').addClass('hidden');
            $('button[name=paymentvisa]').removeClass('hidden');
            $('button[name=paymentatm]').addClass('hidden');
        }
        if ($(this).val() == 'onepay_atm') {
            $('button[name=cod]').addClass('hidden');
            $('button[name=paymentvisa]').addClass('hidden');
            $('button[name=paymentatm]').removeClass('hidden');
        }
    });

    $('#kt_datepicker_1').datepicker({
        todayHighlight: true,
        orientation: "bottom left",
        format: "dd/mm/yyyy",
        maxDate: 1,
        minDate: 0,
        startDate: "0d",
        endDate: "+5d",
    });

    if ($('#sidebar').length && !isMobile) {
        var sidebar = new StickySidebar('#sidebar', {
            containerSelector: '#main-content',
            innerWrapperSelector: '.sidebar__inner',
            topSpacing: 20,
            bottomSpacing: 20
        });
    }
    if ($('.slider-promotion')) {
        $('.slider-promotion').slider();
    }
    $(".slider-promotion").on("slide", function (slideEvt) {
        $("#slider_per").text(slideEvt.value);
    });

    $('.readmore').on('click', function () {
        if ($(this).parent('.sidebar-item').hasClass('show')) {
            $(this).parent('.sidebar-item').removeClass('show').slideDown();
            $(this).text('Xem thêm');
        } else {
            $('.sidebar-item').removeClass('show');
            $(this).parent('.sidebar-item').addClass('show').slideDown();
            $(this).text('Đóng');
        }
    });

    $('.loyalty-register').on('click', function () {
        $('#kt_datepicker_1').datepicker({
            todayHighlight: true,
            orientation: "bottom left",
            format: "dd/mm/yyyy"
        });
        validate_member_form();
    });

    $('.success-close').on('click', function () {
        document.location.href = document.location.href;
    });

    //validate login-----------------
    //-------------------------------
    $("#login_form").validate({
        ignore: null,
        ignore: 'input[type="hidden"]',
        rules: {
            customer_username: {
                required: true
            },
            customer_password: {
                required: true
            }
        },
        messages: {
            customer_username: {
                required: "Please enter your username!"
            },
            customer_password: {
                required: "Please enter the password!"
            }
        }
    });

    //validate signup-----------------
    //--------------------------------
    $("#signup_form").validate({
        ignore: null,
        ignore: 'input[type="hidden"]',
        rules: {
            Name: {
                required: true
            },
            Username: {
                required: true,
                //check username exist
                remote: {
                    data: {
                        username: '#Username'
                    },
                    url: '/account/checkusername',
                    type: "post"
                }
            },
            Phone: {
                required: true,
                number: true,
                minlength: 10,
                maxlength: 15
            },
            Password: {
                required: true
            },
            Password2: {
                required: true,
                equalTo: "#Password"
            },
            Email: {
                required: true
            }
        },
        messages: {
            Name: {
                required: "Please enter your full name!"
            },
            Username: {
                required: "Please enter your username!",
                remote: "Username already in use!"
            },
            Phone: {
                required: "Please enter your phone number!",
                number: "The phone number is not correct!",
                minlength: "The phone number is not correct!",
                maxlength: "The phone number is not correct!"
            },
            Password: {
                required: "Please enter the password!"
            },
            Password2: {
                required: "Please enter the password confirmation!",
                equalTo: "Confirm password was wrong!"
            },
            Email: {
                required: "Please enter your email!"
            }
        }
    });

    if (typeof loadPageLocation != "undefined" && loadPageLocation === true) {
        loadAllStoreList2(-1);
        loadStoreListByCity2(-1);
    } else {
        if (document.getElementById("loading_storelist")) {
            loadAllStoreList(-1);
        }
    }

    $('#group_city').change(function () {
        var city_id = $(this).val();
        var your_address = $("#your_address").val();
        if (city_id == -1) {
            loadAllStoreList2(-1);
        } {
            $.ajax({
                url: root_url + "/auchan/ajax/data",
                dataType: "html",
                type: "POST",
                data: { position: 'getdistrictbycity', id: city_id, your_address: your_address },
                context: $(this),
                success: function (result) {
                    setTimeout(function () {
                        $('#group_district').html(result);
                        loadStoreListByCity(city_id);
                        loadStoreListByCity2(city_id);
                    }, 300);
                }
            });
        }
    });

    $('.d_name').on('click', function () {
        var d_name = $(this).attr('data-name');
        var d_url = $(this).attr('data-url');
        var d_id = $(this).attr('data-did');
        $.cookie('did', d_id, { expires: 180, path: '/' });
        $.ajax({
            url: root_url + '/auchan/ajax/setSession',
            type: "POST",
            dataType: "json",
            data: { d_name: d_name, d_id: d_id, location: location },
            success: function (result) {
                console.log(result.d_name);
                $('#d_name').text(result.d_name);
                document.location.href = d_url;
            }
        });
    });

    var current_address = document.getElementById("current_address");
    var divExists = current_address != null;

    if (divExists == false) {
        localStorage.clear();

        var city_id = $('#cid').val();
        var location = $('input[name=location]:checked').val();
    }

    if (!$('#location').is(':visible')) {
        $(this).find('#checked_radio2').prop('checked', true);
    }

    if (!$('#store_modal').is(':visible')) {
        $(this).find('#checked_radio1').prop('checked', true);
    }


    $('.btn-search-location').click(function () {
        var yadd = $('#geocomplete').val();
        yadd = yadd.replace(/ /g, "+");
        if (!yadd) {
            yadd = '371A Hai Bà Trưng, Phường 8, Quận 3, Hồ Chí Minh';
        }
        getLatLong(yadd);
    });

    $('.tag__icon').on('click', function () {
        $('.tag__icon').removeClass('active');
        $(this).addClass('active');
        var id = $(this).attr('data-product');
        $.ajax({
            url: root_url + '/auchan/ajax/getProducts',
            type: "POST",
            dataType: "json",
            data: { product_id: id },
            success: function (result) {
                if (result.html) {
                    $('#products-decor').html(result.html);
                }
                if (result.related) {
                    $('#title-rel').show();
                    $('#related-products-decor').html(result.related);
                }
            }
        });
    });

    validate_product_review_form_edit();

    $('#filter_form input[name="filter"]').on('click', function () {
        var ar_filter = $('input[name="filter"]:checked').map(function () {
            return this.value;
        }).get();
        var ar_proparent = $('input[name="proparent"]').map(function () {
            return this.value;
        }).get();
        ar_filter.join(",");
        ar_proparent.join(",");
        var page = $('#paging').attr('data-paging');
        var cat_id = $('#product_list').attr('data-cat');
        $.ajax({
            url: root_url + '/auchan/ajax/filterProducts',
            type: "POST",
            dataType: "json",
            data: { filter: ar_filter, cat_id: cat_id, page: page, proparent: ar_proparent },
            beforeSend: function (result) {
                $('#loading_wrapp').html('<div class="loading"><img src="' + theme_url + '/images/loading.gif" /></div>');
            },
            success: function (result) {
                setInterval(function () {
                    $('#loading_wrapp .loading').remove();
                }, 2000);
                if (result.status == 1) {
                    $('#product_list').html(result.products);
                    if (result.page !== null) {
                        $('.paging').html(result.page);
                    }
                } else {
                    $('.paging').empty();
                    $('#product_list').html(result.mess);
                }

                var sidebar = new StickySidebar('#main-sidebar', {
                    containerSelector: '#main-content',
                    innerWrapperSelector: '.sidebar__inner',
                    topSpacing: 50,
                    bottomSpacing: 20,
                });

                if (isMobile) {
                    $('#mobileFilter').removeClass('show-menu');
                    $('.overlay').removeClass('show-overlay');
                    $('body').removeClass('open');
                }

                $('html, body').animate({
                    scrollTop: $("div.group-product-wrapp").offset().top - 130
                }, 1000)
            }
        });
    });


    $("ul.parent_properties").each(function (index) {
        var length = $(this).children('li').length;
        var li_data;
        var count = 0;
        $(this).children('li').each(function () {
            li_data = $(this).attr('data-count');

            if (li_data > 0) {
                count++;
            }
        });
        if (count == 0) {
            $(this).parent('.sidebar-item').hide();
        }
    });

    $('.banner').slick({
        dots: false,
        arrows: false,
        infinite: true,
        speed: 2000,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true
    });

    $('.banner-decor-slider').slick({
        dots: false,
        arrows: false,
        infinite: true,
        speed: 2000,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true
    });

    // if ($('.section-cate').length) {
    //     var num_cat = $('.section-cate').offset().top;
    //     $(window).bind('scroll', function () {
    //         if ($(window).scrollTop() > num_cat + 5) {
    //             $('.section-cate').addClass('fixed');
    //         }
    //         else {
    //             num_cat = $('.section-cate').offset().top;
    //             $('.section-cate').removeClass('fixed');
    //         }
    //     });
    // }

    $('#mobileSidenav ul li .arrow').on('click', function () {
        $(this).toggleClass('active');
        $(this).parent().find('.sub-menu').slideToggle();
    });
    $(window).scroll(function () {
        if ($('#main-sidebar').length) {
            var sidebar = new StickySidebar('#main-sidebar', {
                containerSelector: '#main-content',
                innerWrapperSelector: '.sidebar__inner',
                topSpacing: 50,
                bottomSpacing: 20,
                containerHeight: 600,
                viewportHeight: 600,
                resizeSensor: true,
            });
        }
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#back-top').fadeIn();
        } else {
            $('#back-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-top').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });
});

if ($('#main-sidebar').length) {
    var sidebar = new StickySidebar('#main-sidebar', {
        containerSelector: '#main-content',
        innerWrapperSelector: '.sidebar__inner',
        topSpacing: 50,
        bottomSpacing: 20,
        containerHeight: 600,
        viewportHeight: 600,
        resizeSensor: true,
    });
}


function load_page(obj) {
    var ar_filter = $('input[name="filter"]:checked').map(function () {
        return this.value;
    }).get();
    ar_filter.join(",");
    var page = $('#paging').attr('data-paging');
    page = parseInt(page) + 1;
    var cat_id = $('#product_list').attr('data-cat');
    $.ajax({
        url: root_url + '/auchan/ajax/filterProducts',
        type: "POST",
        dataType: "json",
        data: { filter: ar_filter, cat_id: cat_id, page: page },
        beforeSend: function (result) {
            $('#loading_wrapp').html('<div class="loading"><img src="' + theme_url + '/images/loading.gif" /></div>');
        },
        success: function (result) {
            setInterval(function () {
                $('#loading_wrapp .loading').remove();
            }, 2000);
            if (result.status == 1) {
                $('#product_list').append(result.products);
            }
            if (result.page !== null) {
                $('.paging').html(result.page);
            }
            var sidebar = new StickySidebar('#main-sidebar', {
                containerSelector: '#main-content',
                innerWrapperSelector: '.sidebar__inner',
                topSpacing: 50,
                bottomSpacing: 20,
                containerHeight: 600,
                viewportHeight: 600,
                resizeSensor: true,
            });
        }
    });
}

function load_page2(obj) {
    var page = $(obj).data('paging');
    var url = $(obj).attr('href');
    var page_url = $(obj).data('page');
    $.ajax({
        url: url,
        dataType: "html",
        type: "POST",
        data: { page: page, page_url: page_url },
        context: $(this),
        success: function (html) {
            $('#load-paging-' + page).html(html);
        }
    });
    return false;
}
function setUpToolTipHelpers() {
    $('[data-toggle="tooltip-red"]').tooltip({
        template: '<div class="tooltip red" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
    });
    $('[data-toggle="tooltip-green"]').tooltip({
        template: '<div class="tooltip green" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
    });
    $('[data-toggle="tooltip-default"]').tooltip({
        template: '<div class="tooltip default" role="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
    });
}
$(document).ready(function () {
    get_total_num_cart();
});

function validate_member_form() {
    $("#register_member").validate({
        ignore: null,
        ignore: 'input[type="hidden"]',
        rules: {
            last_name: {
                required: true
            },
            first_name: {
                required: true,
            },
            birthday: {
                required: true
            },
            passport: {
                required: true
            },
            email: {
                required: true
            },
            phone: {
                required: true,
                number: true
            },
            city: {
                required: true
            },
            county: {
                required: true
            },
            ward: {
                required: true
            },
            street: {
                required: true
            }
        },
        messages: {
            last_name: {
                required: 'Vui lòng nhập Họ và Tên Đệm!'
            },
            first_name: {
                required: 'Vui lòng nhập Tên!',
            },
            birthday: {
                required: 'Vui lòng nhập ngày tháng năm sinh!'
            },
            passport: {
                required: 'Vui lòng nhập CMND hoặc Passport!'
            },
            email: {
                required: 'Vui lòng nhập email!'
            },
            phone: {
                required: 'Vui lòng nhập số điện thoại!',
                number: 'Số điện thoại phải là số!'
            },
            city: {
                required: 'Vui lòng chọn Tỉnh/Thành phố!'
            },
            county: {
                required: 'Vui lòng chọn Quận/Huyện!'
            },
            ward: {
                required: 'Vui lòng chọn Phường/Xã!'
            },
            street: {
                required: 'Vui lòng nhập địa chỉ nhà!'
            }
        },
        errorPlacement: function (error, element) {
            var name = $(element).attr("name");
            error.appendTo($("#" + name + "_validate"));
        },
    });
}

function address_book(id, current_id, return_url) {
    $.ajax({
        url: root_url + "/auchan/ajax/AddressBook",
        type: "POST",
        dataType: "html",
        data: { id: id, current_id: current_id, return_url: return_url },
        context: $(this),
        success: function (result) {
            if (result) {
                $('#address_book').html(result);
            }
            $('.selectpicker').selectpicker();
        }
    });
}

function get_ward_popup(id_obj, data) {
    var district_id = data.value;
    $.ajax({
        url: root_url + "/auchan/ajax/GetWard",
        type: "POST",
        dataType: "html",
        data: { district_id: district_id },
        context: $(this),
        success: function (result) {
            console.log('#' + id_obj + '-ward');
            if (result) {
                $('#' + id_obj + '-ward').html(result);
                $('#' + id_obj + '-ward').prop("disabled", false);
                $('.selectpicker').selectpicker("refresh");
            }
        }
    });
}

/*Popup locaton choose*/
function show_popup_location() {
    $('#popup_modal_location').modal('show');
    $('#popup_modal_store').modal('hide');
    $('#popover_location').popover('disable');
}


function get_district(obj) {
    $(document).ready(function () {
        var city_id = $(obj).val();
        if (city_id == '') {
            $('#register_member #group-district').html('<option value="0">Chọn Quận/Huyện</option>');
            $('#register_member #group-ward').html('<option value="0">Chọn Phường/Xã</option>');
            $('.selectpicker').selectpicker("refresh");
            return false;
        }
        $.ajax({
            url: root_url + '/auchan/ajax/getDistrict',
            type: "POST",
            dataType: "json",
            data: { city_id: city_id },
            context: $(obj),
            success: function (result) {
                var html = '';
                if (result.status == 200) {
                    html = show_county_option(result.county);
                }
                $('#register_member #group-district').html(html);
                $('.selectpicker').selectpicker("refresh");
            }
        });
    });
}

function get_ward(obj) {
    var county_id = $(obj).val();
    if (county_id == '') {
        $('#register_member #group-ward').html('<option value="0">Chọn Phường/Xã</option>');
        $('.selectpicker').selectpicker("refresh");
        return false;
    }
    $.ajax({
        url: root_url + '/auchan/ajax/getWardList',
        type: "POST",
        dataType: "json",
        data: { county_id: county_id },
        context: $(obj),
        success: function (result) {
            console.log(result);
            var html = '';
            if (result.Status == 200) {
                html = show_ward_option(result.ward);
            }
            $('#register_member #group-ward').html(html);
            $('.selectpicker').selectpicker("refresh");
        }
    });
}

function show_county_option(data) {
    var html = '<option value="0">Chọn Quận/Huyện</option>';
    for (var i in data) {
        html += '<option value="' + data[i].county_id + '">' + data[i].county_name + '</option>';
    }
    return html;
}

function show_ward_option(data) {
    var html = '<option value="0">Chọn Phường/Xã</option>';
    for (var i in data) {
        html += '<option value="' + data[i].ward_name + '">' + data[i].ward_name + '</option>';
    }
    return html;
}

function close_mess(input_name, messege_class) {
    $(input_name).removeClass('border-danger');
    $('.' + messege_class).removeClass('d-none').addClass('d-none');
}

function save_register_member(element) {
    if ($("#register_member").valid()) {
        $.ajax({
            type: 'POST',
            dataType: "json",
            url: root_url + '/auchan/ajax/saveRegisterMember',
            data: $('#register_member').serialize(),
            context: $(element),
            beforeSend: function (xhr) {
            },
            success: function (resp) {
                if (resp.message == 'success') {
                    $('#loyalty-register').removeClass('in').hide();
                    $('#success_register_member').addClass('in').show();
                } else {
                    alert(resp.message);
                }
            }
        });
    }
}


/*
 * Hiển thị khi click vào Store
 */
function slimscroll() {
    if ($("#slimscroll").hasClass("slimscroll")) {
        $('#loading_storelist2').slimscroll({
            height: 'calc(60vh - 40px)'
        });
    }
}

function loadAllStoreList2($obj) {
    var city_id = $obj;
    $.ajax({
        url: root_url + "/auchan/ajax/data",
        dataType: "json",
        type: "POST",
        data: { position: 'getallstorelist2', id: city_id, limit: 100, type: 2 },
        context: $(this),
        success: function (result) {
            $('#loading_storelist2').html(result.script);
            slimscroll();
        }
    });
}
function GetBranchAdd(obj) {
    $.ajax({
        url: root_url + "/auchan/ajax/GetBranchAdd",
        dataType: "html",
        data: { code: obj },
        context: $(this),
        success: function (r) {
            $('#getscript').html(r);
            $('html, body').animate({
                scrollTop: $("#map").offset().top
            }, 1000);
        }
    });
}


function getListStoreNearYou2(latitude, longitude) {
    $('#lng').val(longitude);
    $('#lat').val(latitude);
    $.ajax({
        url: root_url + "/auchan/ajax/getNearStores",
        dataType: "json",
        data: {
            Lat: latitude,
            Long: longitude
        },
        cache: !0,
        context: $(this),
        success: function (j) {
            $('.nearest').removeClass('hidden');
            $('#getscript').html(j.script);
        }
    });
}

function findStreet(toadd) {
    var fromadd = $('#geocomplete').val();
    $.ajax({
        url: root_url + "/auchan/ajax/findStreet",
        dataType: "html",
        data: { from: fromadd, to: toadd },
        context: $(this),
        success: function (r) {
            //console.log(r);
            $('html, body').animate({
                scrollTop: $("#map").offset().top
            }, 1000);
            $('#getscript').html(r);
            slimscroll();
        }
    });
}

function loadStoreListByCity2($obj) {
    var city_id = $obj;
    $.ajax({
        url: root_url + "/auchan/ajax/data",
        dataType: "json",
        type: "POST",
        data: { position: 'getstorelistbycity2', id: city_id, limit: 100 },
        context: $(this),
        success: function (result) {

            $('#loading_storelist2').html(result.content);
            $('#getscript').html(result.script);
            slimscroll();
        }
    });
}

function loadStoreListByCity($obj) {
    var city_id = $obj;
    $.ajax({
        url: root_url + "/auchan/ajax/data",
        dataType: "html",
        type: "POST",
        data: { position: 'getstorelistbycity', id: city_id, limit: 100 },
        context: $(this),
        success: function (result) {
            $('#loading_storelist').html(result);
            slimscroll();
        }
    });
}

if (document.getElementById("geocomplete")) {
    $("#geocomplete").geocomplete({
        country: 'VNM',
        type: ["postal_code", "neighborhood"]
    }).bind("geocode:result", function (event, result) {
        //console.log(result.geometry.location.lat);
        var yadd = $('#geocomplete').val();
        yadd = yadd.replace(/ /g, "+");
        getLatLong(yadd);
    });
}

function getLatLong(add) {
    $.get('https://maps.googleapis.com/maps/api/geocode/json?key=' + google_api + '&address=' + add + '&sensor=true', function (data) {
        if (data.status == "OK") {
            getListStoreNearYou2(data.results[0].geometry.location.lat, data.results[0].geometry.location.lng);
        }
    });
}

function nearlistchange(obj) {
    findStreet(obj.value);
}

function appendInput(obj) {
    var html = '<li class="enter_address" style="display:none;"><div class="form-control findto"></div></li>';
    $('.enter_address').remove();
    $('.showmap').css("background-color", '');

    $(html).insertAfter(".add" + $(obj).attr('data-id'));
    $(".add" + $(obj).attr('data-id')).css("background-color", 'rgba(255, 186, 81, 0.12)');
    $('.findto').attr("data-add", $(obj).attr('data-address'));
    $('.findto').html($(obj).attr('data-address') + '<div class="go_map"><a href="javascript:;" onClick="findStreet();" class="btn btn-sm text-success"><i class="auc auc-search" style="display:none;"></i></a></div>');
    findStreet();
}

function findStreet(toadd) {
    var fromadd = $('#geocomplete').val();
    $.ajax({
        url: "/auchan/ajax/findStreet",
        dataType: "html",
        data: { from: fromadd, to: toadd },
        context: $(this),
        success: function (r) {
            //console.log(r);
            $('html, body').animate({
                scrollTop: $("#map").offset().top
            }, 1000);
            $('#getscript').html(r);
            slimscroll();
        }
    });
}

function validate_product_review_form_edit() {
    $("#product_review").validate({
        ignore: null,
        ignore: 'input[type="hidden"], [readonly=readonly]',
        rules: {
            fullname: {
                required: true,
            },
            email: {
                required: true,
                email: true
            },
            comment: {
                required: true
            }
        },
        messages: {
            fullname: {
                required: "Vui lòng nhập Họ Tên!",
            },
            email: {
                required: "Vui lòng nhập Email!",
                email: 'Email không đúng!'
            },
            comment: {
                required: "Vui lòng nhập Lời nhắn!"
            }
        }
    });
}

function show_review() {
    $('#product_review').find("input[type=text], input[type=file], textarea").val("");
    $("#products_comment_review").slideDown();
}

function save_product_comment(el) {
    var data = new FormData();
    //Form data
    var form_data = $('#product_review').serializeArray();
    $.each(form_data, function (key, input) {
        data.append(input.name, input.value);
    });
    //File data
    var file_data = $('input[name="file_image"]')[0].files;
    for (var i = 0; i < file_data.length; i++) {
        data.append("my_images[]", file_data[i]);
    }

    if ($("#product_review").valid()) {
        $.ajax({
            url: root_url + "/auchan/ajax/saveProductComment",
            dataType: "json",
            type: "POST",
            data: data,
            processData: false,
            contentType: false,
            success: function (result) {
                if (result.status == 1) {
                    $('#product_review').find("input[type=text], input[type=file], textarea").val("");
                    $('#review_message').addClass('success').slideDown().text(result.msg);
                    setInterval(function () {
                        $("#products_comment_review").slideUp();
                        $("#review_message").removeClass('success');
                        $("#review_message").slideUp();
                    }, 5000);
                } else {
                    $("#review_message").addClass('error')
                    $("#review_message").slideDown();
                    $('#review_message').text(result.msg);
                }
            }
        });
    }
}


// ***************************
// *
// * WISHLIST
// *
// ***************************

function wishlist(object) {
    var productid = $(object).data('id');
    var action = $($(object)[0].outerHTML).data('action');
    console.log($(object)[0].outerHTML);
    if (typeof productid != "undefined" && action != 'login') {
        if (action == 'add') {
            add_wishlist(object);
        } else if (action == 'remove') {
            remove_wishlist(object);
        }
    }
}

function add_wishlist(object) {
    var productid = $(object).data('id');
    if (productid > 0) {
        $.ajax({
            url: root_url + "/member/favlist.html",
            dataType: "json",
            type: "POST",
            data: { product_id: productid, action: 'add' },
            context: $(this),
            success: function (result) {
                if (result.error == false) {
                    //localStorage.setItem('wishlist_'+productid, 1);
                    $(object).addClass('active');
                    $.cookie('wl' + productid, '1', { expires: 2400, path: '/' });
                    $(object).attr("data-action", "remove");
                    $(object).html('<img width="20" src="' + theme_url + '/images/like-3.png">Đã lưu');
                }
            }
        });
    }
}

function remove_wishlist(object) {
    var productid = $(object).data('id');
    if (productid > 0) {
        $.ajax({
            url: root_url + "/member/favlist.html",
            dataType: "json",
            type: "POST",
            data: { product_id: productid, action: 'remove' },
            context: $(this),
            success: function (result) {
                if (result.error == false) {
                    $(object).removeClass('active');
                    $.cookie('wl' + productid, '1', { expires: -1, path: '/' });
                    $('#wl' + productid).remove();
                    $(object).attr("data-action", "add");
                    $(object).html('<img width="20" src="' + theme_url + '/images/like-2.png">Yêu thích');
                }
            }
        });
    }
}
// ***************************
// *
// * END WISHLIST
// *
// ***************************
// ***************************
// *
// * SEARCH HEADER
// *
// ***************************

$('#placeholder-type-writter').mouseup(function () {
    $('.completesearch').html('');
});
$('#placeholder-type-writter').keyup(function () {
    var len = $(this).val().length;
    if (len >= 3) {
        $.ajax({
            url: root_url + "/dlhf/ajax/CompleteSearch",
            dataType: "html",
            data: { position: 'search', key: $(this).val() },
            context: $(this),
            success: function (result) {
                $('.completesearch').html('<div class="auto-complete-search-box">' + result + '</div>');
            }
        });
        return false;
    } else {
        $('.completesearch').html('');
    }

});


$(document).ready(function () {
    $(document).on('click', '.detail-product-search', function () {
        var url = $(this).data('url');
        var key_search = $('#placeholder-type-writter').val();
        $.ajax({
            url: root_url + "/dlhf/ajax/linksearch",
            dataType: "html",
            data: { position: 'linksearch', key: key_search },
            context: $(this),
            success: function (result) {
                window.location.href = url;
            }
        });
    });
    var dist_name = $('#d_name').attr('data-dist');
    if (dist_name == '') {
        $('#location_modal')[0].click();
        $('#close_modal').addClass('hidden');
    }

});
// ***************************
// *
// * END SEARCH HEADER
// *
// ***************************


function check_valid_phone_new(text) {
    if (text == '') {
        return false;
    }
    var phone = text.replace(/\s/g, "");
    var filter = /^(096|097|098|090|093|089|091|094|088|092|095|0188|0186|0199|0162|0163|0164|0165|0166|0167|0120|0121|0122|0126|0128|0123|0124|0125|0127|0129|0168|0169|032|033|034|035|036|037|038|039|070|079|077|076|078|083|084|085|081|082|056|058|059|052|086|099)[0-9]{7}$/;
    if (filter.test(phone)) {
        return true;
    } else {
        return false;
    }
}
function openNav() {
    document.getElementById("mobileSidenav").style.width = "70%";
    $('#mobileSidenav').addClass('show-menu');
    $('.overlay').addClass('show-overlay');
    $('body').addClass('open');
}

function closeNav() {
    document.getElementById("mobileSidenav").style.width = "0";
    $('#mobileSidenav').removeClass('show-menu');
    $('.overlay').removeClass('show-overlay');
    $('body').removeClass('open');
}

function openFilter() {
    document.getElementById("mobileFilter").style.width = "80%";
    $('#mobileFilter').addClass('show-menu');
    $('.overlay').addClass('show-overlay');
    $('body').addClass('open');
}

function closeFilter() {
    document.getElementById("mobileSidenav").style.width = "0";
    $('#mobileFilter').removeClass('show-menu');
    $('.overlay').removeClass('show-overlay');
    $('body').removeClass('open');
}
$(document).ready(function () {
    $('.overlay').on('click', function () {
        $('#mobileFilter').removeClass('show-menu');
        $('#mobileSidenav').removeClass('show-menu');
        $(this).removeClass('show-overlay');
        $('body').removeClass('open');
    });
});

function clearAllFilter() {
    $('input[name="filter"], input[name="proparent"]').prop('checked', false);
    var ar_filter = $('input[name="filter"]:checked').map(function () {
        return this.value;
    }).get();
    var ar_proparent = $('input[name="proparent"]').map(function () {
        return this.value;
    }).get();
    ar_filter.join(",");
    ar_proparent.join(",");
    var page = $('#paging').attr('data-paging');
    var cat_id = $('#product_list').attr('data-cat');
    $.ajax({
        url: root_url + '/auchan/ajax/filterProducts',
        type: "POST",
        dataType: "json",
        data: { filter: ar_filter, cat_id: cat_id, page: page, proparent: ar_proparent },
        beforeSend: function (result) {
            $('#loading_wrapp').html('<div class="loading"><img src="' + theme_url + '/images/loading.gif" /></div>');
        },
        success: function (result) {
            setInterval(function () {
                $('#loading_wrapp .loading').remove();
            }, 2000);
            if (result.status == 1) {
                $('#product_list').html(result.products);
                if (result.page !== null) {
                    $('.paging').html(result.page);
                }
            } else {
                $('.paging').empty();
                $('#product_list').html(result.mess);
            }

            var sidebar = new StickySidebar('#main-sidebar', {
                containerSelector: '#main-content',
                innerWrapperSelector: '.sidebar__inner',
                topSpacing: 50,
                bottomSpacing: 20,
            });

            if (isMobile) {
                $('#mobileFilter').removeClass('show-menu');
                $('.overlay').removeClass('show-overlay');
                $('body').removeClass('open');
            }

            $('html, body').animate({
                scrollTop: $("div.group-product-wrapp").offset().top - 130
            }, 1000)
        }
    });
}