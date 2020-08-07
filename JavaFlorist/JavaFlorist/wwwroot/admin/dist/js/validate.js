jQuery(document).ready(function () {
    $("#login_form").validate({
        rules: {
            admin_username: {
                required: true
            },
            admin_password: {
                required: true
            }
        },
        messages: {
            admin_username: {
                required: "Please enter your username!"
            },
            admin_password: {
                required: "Please enter the password!"
            }
        },
        errorPlacement: function (error, element) {
            var placement = $(element).data('error');
            if (placement) {
                $(placement).append(error)
            } else {
                error.insertAfter(element);
            }
        }
    });

    $("#signup_form").validate({
        rules: {
            Name: {
                required: true
            },
            Username: {
                required: true

            },
            Phone: {
                required: true,
                number: true,
                //minlength: 10,
                //maxlength: 15
            },
            Password: {
                required: true
            },
            Password2: {
                required: true,
                equalTo: "#password"
            },
            Email: {
                required: true
            },
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
            },
        },
        errorPlacement: function (error, element) {
            var placement = $(element).data('error');
            if (placement) {
                $(placement).append(error)
            } else {
                error.insertAfter(element);
            }
        }
    });

    $("#bouquet-form").validate({
        rules: {
            "Bouquet.Name": {
                required: true
            },
            "Bouquet.Description": {
                required: true,
                minlength: 5
            },
            "Bouquet.Price": {
                required: true,
                digits: true
            }
        },
        messages: {
            "Bouquet.Name": {
                required: 'Please enter bouquet name.'
            },
            "Bouquet.Description": {
                required: 'Please enter bouquet description.',
                minlength: 'Please enter more word.'
            },
            "Bouquet.Price": {
                required: 'Please enter bouquet price.',
                digits: 'Please enter number of price.'
            }
        },

    });

    $("#mess-form").validate({
        rules: {
            MeContent: {
                required: true,
                minlength: 10
            },
            OccasionId: {
                required: true
            }
        },
        messages: {
            MeContent: {
                required: 'Please enter the message.',
                minlength: 'Please enter more word.'
            },
            OccasionId: {
                required: 'Please choose an occasion.',
            }
        },
    });

    $("#occasion-form").validate({
        rules: {
            Name: {
                required: true,
                minlength: 5
            },
            Description: {
                required: true,
                minlength: 5
            },
            StartMonth: {
                required: true,
                digits:true
            },
            EndMonth: {
                required: true,
                digits: true
            }
        },
        messages: {
            Name: {
                required: 'Please enter the occasion name.',
                minlength: 'Please enter more word.'
            },
            Description: {
                required: 'Please enter the occasion description.',
                minlength: 'Please enter more word.'
            },
            StartMonth: {
                required: 'Please enter the occasion start month in year.',
                digits: 'this must be number.'
            },
            EndMonth: {
                required: 'Please enter the occasion end month in year.',
                digits: 'this must be number.'
            }
        },
    });

})