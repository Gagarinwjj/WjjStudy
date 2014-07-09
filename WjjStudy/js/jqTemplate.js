
// jQuery Plugin Boilerplate
// A boilerplate for jumpstarting jQuery plugins development
// version 2.0, July 8th, 2011
// by Stefan Gabos

// remember to change every instance of "pluginName" to the name of your plugin!
// the semicolon at the beginning is there on purpose in order to protect the integrity 
// of your scripts when mixed with incomplete objects, arrays, etc.

//记得把"pluginName" 改成你自己的插件名!
//开始的分号是为了保证你脚本的完整性，避免和没加";"结束的对象、数组混合。
; (function ($) {
    // we need attach the plugin to jQuery's namespace or otherwise it would not be
    // available outside this function's scope
    // "el" should be a jQuery object or a collection of jQuery objects as returned by
    // jQuery's selector engine
    //我们需要附加插件到jQuery的命名空间，否则插件这个函数作用域之外便不可使用。
    //"el"应该是由jQuery选择器引擎返回的jQuery的对象或对象集合
    $.pluginName = function (el, options) {

        // plugin's default options
        // this is private property and is accessible only from inside the plugin
        //插件默认配置，私有属性，仅可以从插件内部访问。
        var defaults = {

            propertyName: 'value',

            // if your plugin is event-driven, you may provide callback capabilities 
            // for its events. call these functions before or after events of your 
            // plugin, so that users may "hook" custom functions to those particular 
            // events without altering the plugin's code
            //如果你的插件是事件驱动的，你需要为事件提供回调函数。在插件触发某一事件前后调用这些函数，
            //因此用户可以"绑定"自定义的函数到这些特定事件且不用修改代码。
            onSomeEvent: function () { }

        }

        // to avoid confusions, use "plugin" to reference the
        // current instance of the  object
        //为了避免混淆，使用"plugin"来引用当前的插件对象实例。
        var plugin = this;

        // this will hold the merged default, and user-provided options
        // plugin's properties will be accessible like:
        // plugin.settings.propertyName from inside the plugin or
        // myplugin.settings.propertyName from outside the plugin
        // where "myplugin" is an instance of the plugin
        //这是一个合并了默认属性(default)和用户提供的属性(options)之后的插件属性。
        //它可以这么来访问：
        //插件内部：plugin.settings.propertyName
        //插件外部：myplugin.settings.propertyName(myplugin是一个插件实例)
        plugin.settings = {}

        // the "constructor" method that gets called when the object is created
        // this is a private method, it can be called only from inside the plugin
        //插件对象被创建时候调用的构造函数
        //这是一个私有函数，仅可以从插件内部调用
        var init = function () {

            // the plugin's final properties are the merged default and 
            // user-provided options (if any)
            //插件最终属性是合并default和options之后的属性
            plugin.settings = $.extend({}, defaults, options);

            // make the collection of target elements available throughout the plugin
            // by making it a public property
            //将目标元素作为插件的公有属性，这样就可通过插件来访问了
            plugin.el = el;

            // code goes here

        }

        // public methods
        // these methods can be called like:
        // plugin.methodName(arg1, arg2, ... argn) from inside the plugin or
        // myplugin.publicMethod(arg1, arg2, ... argn) from outside the plugin
        // where "myplugin" is an instance of the plugin

        // a public method. for demonstration purposes only - remove it!
        //共有属性，可以这么来调用
        //插件内部：methodName(arg1, arg2, ... argn)
        //插件外部：myplugin.publicMethod(arg1, arg2, ... argn)(myplugin是一个实例对象)
        //public方法，仅作演示，可删！
        plugin.foo_public_method = function () {

            // code goes here

        }

        // private methods
        // these methods can be called only from inside the plugin like:
        // methodName(arg1, arg2, ... argn)
        
        // a private method. for demonstration purposes only - remove it!

        //私有方法
        //这些方法仅可以从插件内部调用
        //methodName(arg1,arg2,...argn)
        //私有方法，仅作演示，可删！
        var foo_private_method = function () {

            // code goes here

        }

        // call the "constructor" method
        //调用构造函数
        init();

    }

})(jQuery);


//没有注释版
; (function ($) {

    $.pluginName = function (el, options) {

        var defaults = {
            propertyName: 'value',
            onSomeEvent: function () { }
        }

        var plugin = this;

        plugin.settings = {}

        var init = function () {
            plugin.settings = $.extend({}, defaults, options);
            plugin.el = el;
            // code goes here
        }

        plugin.foo_public_method = function () {
            // code goes here
        }

        var foo_private_method = function () {
            // code goes here
        }

        init();

    }

})(jQuery);

//使用
$(document).ready(function () {
    // create a new instance of the plugin
    var myplugin = new $.pluginName($('#element'));

    // call a public method
    myplugin.foo_public_method();

    // get the value of a public property
    myplugin.settings.property;

});
