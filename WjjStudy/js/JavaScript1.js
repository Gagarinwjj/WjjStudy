; (function ($) {
    //构造函数
    $.pluginName = function (el, options) {
        //去除构造函数中对插件的初始化，转到$.fn.pluginName中初始化。
        return $(el).pluginName(options);//该构造函数不是给插件使用，而是给外部调用者使用,需要return以链式编程
    }
    //②：原型方法定义（均为共有方法）
    $.pluginName.prototype = {
        method1: function (para1, para2) {
        },
        method2: function (para1, para2) {
        }
    };

    //③：原型方法定义 也可以这么写（均为共有方法）
    //$.extend($.pluginName, {
    //    method1: function () {
    //    },
    //    method2: function () {
    //    }
    //});

    //在插件中使用，不会创建插件实例（构造函数是给外部使用的）
    $.fn.pluginName = function (options) {
        var defaults = {
            propertyName: 'value',
            onSomeEvent: function () { }
        }

        var settings = {}

        var init = function () {
            settings = $.extend({}, defaults, options);
            // code goes here
        }

        var foo_private_method = function () {
            //私有方法
            // code goes here
        }

        init();

        //调用业务方法
        $.pluginName.method1(para1, para2);
        $.pluginName.method2(para1, para2);

        //返回 this，便于链式调用
        return this;
    }

})(jQuery);

$(document).ready(function () {
    //熟悉的链式编程
    $('#element').pluginName({
        //插件options
    }).css({}).show({});

    //构造函数提供该外部使用，所以相当于
    new $.pluginName($('#element'), {
        //插件options
    }).css({}).animate({});
});