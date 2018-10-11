// Página principal

$('#myAffix').affix({
    offset: {
        top: 100,
        bottom: function () {
            return (this.bottom = $('.footer').outerHeight(true))
        }
    }
})

$(document).ready(function () {

    $(".navbar a, footer a[href='#myPage']").on('click', function (event) {

        if (this.hash !== "") {

            event.preventDefault();

            var hash = this.hash;

            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 900, function () {
                window.location.hash = hash;
            });
        }
        $('html, body').animate({ scrollTop: 0 }, 'fast');
    });

    $(window).scroll(function () {
        $(".slideanim").each(function () {
            var pos = $(this).offset().top;

            var winTop = $(window).scrollTop();
            if (pos < winTop + 600) {
                $(this).addClass("slide");
            }
        });
    });
});

$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $("body").addClass("changeColor");
            $("video").addClass("video2");
            $("#up").removeClass("logo4");
            $("#up").addClass("logo5");
        }
        if ($(this).scrollTop() < 50) {
            $("body").removeClass("changeColor");
            $("video").addClass("video");
            $("video").removeClass("video2");
            $("#up").removeClass("logo5");
            $("#up").addClass("logo4");
        }
    });
});

//Open modal on pageload
$(window).on('load', function () {
    $('#loginModal').modal('show');
});

//Select Contratos AJAX
$(document).ready(function () {
    $("#contratos").change(function () {
        $("#log").ajaxError(function (event, jqxhr, settings, exception) {
            alert(exception);
        });
        var _this = $(this);
        $("#msg").hide();
        $("#icon").hide();
        $("#contratosPartial").hide();
        $("#progress").show();
        _this.attr('disabled', 'disabled');
        var dias = $("select option:selected").first().val();

        $.get('Home/Contratos', { id: dias }, function (data) {
            _this.removeAttr("disabled", "disabled");
            //hide the progress bar div e show o icone salvar
            $("#icon").show();
            $("#progress").hide();
            $("#msg").show();
            $("#msg").text('');
            $("#contratosPartial").show();
            $("#contratosPartial").html(data);
        });
    });
});

//Select Pagamentos AJAX
$(document).ready(function () {
    $("#pagamentos").change(function () {
        $("#pagamentosLog").ajaxError(function (event, jqxhr, settings, exception) {
            alert(exception);
        });
        var _this = $(this);
        $("#pagamentosMsg").hide();
        $("#icon").hide();
        $("#pagamentosPartial").hide();
        $("#pagamentosProgress").show();
        _this.attr('disabled', 'disabled');
        var dias = $("select option:selected").first().val();

        $.get('Home/Pagamentos', { id: dias }, function (data) {
            _this.removeAttr("disabled", "disabled");
            //hide the progress bar div e show o icone salvar
            $("#icon").show();
            $("#pagamentosProgress").hide();
            $("#pagamentosMsg").show();
            $("#pagamentosMsg").text('');
            $("#pagamentosPartial").show();
            $("#pagamentosPartial").html(data);
        });
    });
});

//Select Lembretes AJAX
$(document).ready(function () {
    $("#lembretes").change(function () {
        $("#lembretesLog").ajaxError(function (event, jqxhr, settings, exception) {
            alert(exception);
        });
        var _this = $(this);
        $("#lembretesMsg").hide();
        $("#icon").hide();
        $("#lembretesPartial").hide();
        $("#lembretesProgress").show();
        _this.attr('disabled', 'disabled');
        var dias = $("select option:selected").first().val();

        $.get('Home/Lembretes', { id: dias }, function (data) {
            _this.removeAttr("disabled", "disabled");
            //hide the progress bar div e show o icone salvar
            $("#icon").show();
            $("#lembretesProgress").hide();
            $("#lembretesMsg").show();
            $("#lembretesMsg").text('');
            $("#lembretesPartial").show();
            $("#lembretesPartial").html(data);
        });
    });
});

//Select Aniversariantes AJAX
$(document).ready(function () {
    $("#aniversariantes").change(function () {
        $("#aniversariantesLog").ajaxError(function (event, jqxhr, settings, exception) {
            alert(exception);
        });
        var _this = $(this);
        $("#aniversariantesMsg").hide();
        $("#icon").hide();
        $("#aniversariantesPartial").hide();
        $("#aniversariantesProgress").show();
        _this.attr('disabled', 'disabled');
        var dias = $("select option:selected").first().val();

        $.get('Home/Aniversariantes', { id: dias }, function (data) {
            _this.removeAttr("disabled", "disabled");
            //hide the progress bar div e show o icone salvar
            $("#icon").show();
            $("#aniversariantesProgress").hide();
            $("#aniversariantesMsg").show();
            $("#aniversariantesMsg").text('');
            $("#aniversariantesPartial").show();
            $("#aniversariantesPartial").html(data);
        });
    });
});




