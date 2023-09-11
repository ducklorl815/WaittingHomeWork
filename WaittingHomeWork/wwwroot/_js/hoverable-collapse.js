(function ($) {
    'use strict';

    $(document).on('mouseenter mouseleave', '.sidebar .nav-item', function (ev) {
        var body = $('body');

        if (!('ontouchstart' in document.documentElement) && body.hasClass("sidebar-icon-only")) {
            if (body.hasClass("sidebar-fixed") && ev.type === 'mouseenter') {
                body.removeClass('sidebar-icon-only');
            } else {
                if (ev.type === 'mouseenter') {
                    $(this).addClass('hover-open');
                } else {
                    $(this).removeClass('hover-open');
                }
            }
        }
    });
})(jQuery);
