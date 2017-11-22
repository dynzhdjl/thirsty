(function ($, undefined) {
    "use strict";

    var $form = $('#hede');

    function setupGlasswareRadioButtons() {
        $('input:radio[name="glassware-group"]').change(
            function () {
                if ($(this).is(':checked')) {
                    $("#GlasswareId").val($(this).val());
                }
                $form.submit();
            });
    }

    function setupStylesRadioButtons() {
        $('input:radio[name="style-group"]').change(
            function () {
                if ($(this).is(':checked')) {
                    $("#StyleId").val($(this).val());
                }
                $form.submit();
            });
    }

    function setupAvailabilityRadioButtons() {
        $('input:radio[name="availability-group"]').change(
            function () {
                if ($(this).is(':checked')) {
                    $("#AvailabilityId").val($(this).val());
                }
                $form.submit();
            });
    }

    function setupNextPageLink() {
        $('#next-page-link').on('click', function (e) {
            $('#Page').val($(this).data("index"));
            $form.submit();
            e.preventDefault();
        });

        $('#prev-page-link').on('click', function (e) {
            $('#Page').val($(this).data("index"));
            $form.submit();
            e.preventDefault();
        });
    }

    function setupSortProperties() {
        //bootstrap unstable verion workaround
        $(document).on("change", "select", function () {
            $("option[value=" + this.value + "]", this)
                .attr("selected", true).siblings()
                .removeAttr("selected");
            $form.submit();
        });
    }

    $(document).ready(function () {
        setupAvailabilityRadioButtons();
        setupStylesRadioButtons();
        setupGlasswareRadioButtons();
        setupSortProperties();
        setupNextPageLink();
    });
})(jQuery);