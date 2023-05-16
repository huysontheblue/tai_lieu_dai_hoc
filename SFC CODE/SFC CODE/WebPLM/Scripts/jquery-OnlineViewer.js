/*--
  * FAQ - jQuery Plugin (v3.5)
 * Copyright 2013, www.luxshare-ict.com
 * Change by: huasong ke
 * mail:huasong.ke@luxshare-ict.com
 * Date: 2013-10-22
*/
(function($) {
	$.fn.extend({
		AeroWindow: function(options) {
			WindowID = $(this).attr('id');
			if (($('body').data(WindowID)) == null) {
				var $WindowAllwaysRegistered = false;
				$('body').data(WindowID, 1)
			} else {
				var $WindowAllwaysRegistered = true
			}
			if ($WindowAllwaysRegistered == true && options.WindowIsSame == true) {
				Window = $(this).find(".AeroWindow");
				$(this).find(".AeroWindow").css('display', 'block');
				$(".AeroWindow").removeClass('active');
				if (Window.hasClass('AeroWindow')) Window.addClass('active');
				if (($('body').data('AeroWindowMaxZIndex')) == null) {
					$('body').data('AeroWindowMaxZIndex', Window.css('z-index'))
				}
				i = $('body').data('AeroWindowMaxZIndex');
				i++;
				Window.css('z-index', i);
				$('body').data('AeroWindowMaxZIndex', Window.css('z-index'));
				return
			}
			var defaults = {
				WindowTitle: null,
				WindowPositionTop: 60,
				WindowPositionLeft: 20,
				WindowWidth: 300,
				WindowHeight: 300,
				WindowMinWidth: 250,
				WindowMinHeight: 0,
				WindowResizable: false,
				WindowMaximize: false,
				WindowMinimize: false,
				WindowClosable: true,
				WindowDraggable: true,
				WindowStatus: 'regular',
				WindowAnimationSpeed: 500,
				WindowAnimation: 'easeOutElastic',
				WindowUrl: 'http://www.baidu.com',
				WindowIsSame: true
			};
			var options = $.extend(defaults, options);
			return this.each(function() {
				var o = options;
				var s = document.getElementById("iframeHelper");
				if (s) {} else {
					$(this).html("<iframe  src='" + o.WindowUrl + "' width='100%' height='100%' style='border: 0px;' frameborder='0'></iframe><div id='iframeHelper'></div>")
				}
				var WindowContent = $(this).html();
				if (o.WindowMinimize) {
					if (o.WindowMaximize || o.WindowClosable) {
						var WinMinBtn = '<a href="#" class="win-min-btn"></a><div class="win-btn-spacer"></div>'
					} else {
						var WinMinBtn = '<a href="#" class="win-min-btn"></a>'
					}
				} else {
					var WinMinBtn = ''
				}
				if (o.WindowMaximize) {
					if (o.WindowClosable) {
						var WinMaxBtn = '<div class="WinBtnSet winmax"><a href="#" class="win-max-btn"></a><div class="win-btn-spacer"></div></div>';
						var WinRegBtn = '<div class="WinBtnSet winreg"><a href="#" class="win-reg-btn"></a><div class="win-btn-spacer"></div></div>'
					} else {
						var WinMaxBtn = '<div class="WinBtnSet winmax"><a href="#" class="win-max-btn"></a></div>';
						var WinRegBtn = '<div class="WinBtnSet winreg"><a href="#" class="win-reg-btn"></a></div>'
					}
				} else {
					var WinMaxBtn = '';
					var WinRegBtn = ''
				}
				if (o.WindowClosable) {
					var WinCloseBtn = '<a href="#" class="win-close-btn"></a>'
				} else {
					var WinCloseBtn = ''
				}
				if (o.WindowMinimize || o.WindowMaximize || o.WindowClosable) {
					var WinBtnLeftedge = '<div class="win-btn-leftedge"></div>';
					var WinBtnRightedge = '<div class="win-btn-rightedge"></div>'
				} else {
					var WinBtnLeftedge = '';
					var WinBtnRightedge = ''
				}
				$(this).html('<div class="AeroWindow">  <table cellpadding="0" cellspacing="0" border="0">    <tr>      <td class="table-tl"></td>      <td class="table-tm"></td>      <td class="table-tr"></td>    </tr>    <tr>      <td class="table-lm"></td>      <td class="table-mm" align="right">        <div class="title"><nobr>' + o.WindowTitle + '</nobr></div>        <div class="winbuttons">' + WinBtnLeftedge + WinMinBtn + WinMaxBtn + WinRegBtn + WinCloseBtn + WinBtnRightedge + '        </div>        <div class="table-mm-container" align="left">          <div class="table-mm-content" style="width: ' + o.WindowWidth + 'px;height: ' + o.WindowHeight + 'px;">' + WindowContent + '          </div>        </div>      </td>      <td class="table-rm"></td>    </tr>    <tr>      <td class="table-bl"></td>      <td class="table-bm"></td>      <td class="table-br"></td>    </tr>  </table></div>');
				$(this).css('display', 'block');
				var Window = $(this).find(".AeroWindow");
				var WindowContainer = $(this).find(".table-mm-container");
				var WindowContent = $(this).find(".table-mm-content");
				var BTNMin = $(this).find(".win-min-btn");
				var BTNMax = $(this).find(".WinBtnSet.winmax");
				var BTNReg = $(this).find(".WinBtnSet.winreg");
				var BTNClose = $(this).find(".win-close-btn");
				BTNReg.css('display', 'none');
				FocusWindow(Window);
				if (o.WindowPositionTop == 'center') {
					o.WindowPositionTop = ($(window).height() / 2) - o.WindowHeight / 2 - 37
				}
				if (o.WindowPositionLeft == 'center') {
					o.WindowPositionLeft = ($(window).width() / 2) - o.WindowWidth / 2 - 17
				}
				switch (o.WindowStatus) {
				case 'regular':
					RegularWindow();
					break;
				case 'maximized':
					MaximizeWindow();
					break;
				case 'minimized':
					MinimizeWindow();
					break;
				default:
					break
				}
				function MaximizeWindow() {
					WindowContainer.css('visibility', 'visible');
					BTNMax.css('display', 'none');
					BTNReg.css('display', 'block');
					WindowContent.animate({
						width: $(window).width() - 32,
						height: $(window).height() - 52
					},
					{
						queue: false,
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					Window.animate({
						width: $(window).width(),
						height: $(window).height(),
						top: 0,
						left: 0
					},
					{
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					o.WindowStatus = 'maximized';
					return (false)
				}
				function MinimizeWindow() {
					BTNReg.css('display', 'block');
					BTNMax.css('display', 'none');
					WindowContainer.css('visibility', 'hidden');
					WindowContent.animate({
						width: o.WindowMinWidth,
						height: o.WindowMinHeight
					},
					{
						queue: true,
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					Window.animate({
						width: o.WindowMinWidth + 32,
						height: o.WindowMinHeight + 72,
						top: $(window).height() - 52,
						left: 0
					},
					{
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					o.WindowStatus = 'minimized';
					return (false)
				}
				function RegularWindow() {
					BTNMax.css('display', 'block');
					BTNReg.css('display', 'none');
					WindowContainer.css('visibility', 'visible');
					WindowContent.animate({
						width: o.WindowWidth,
						height: o.WindowHeight
					},
					{
						queue: false,
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					Window.animate({
						width: o.WindowWidth + 32,
						height: o.WindowHeight + 72
					},
					{
						queue: false,
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					if ((typeof(o.WindowPositionLeft) == 'string') && (o.WindowPositionLeft.substring(0, 1) == '-')) o.WindowPositionLeft = 0;
					Window.animate({
						top: o.WindowPositionTop,
						left: o.WindowPositionLeft
					},
					{
						duration: o.WindowAnimationSpeed,
						easing: o.WindowAnimation
					});
					o.WindowStatus = 'regular';
					return (false)
				}
				function FocusWindow(Window) {
					$(".AeroWindow").removeClass('active');
					if (Window.hasClass('AeroWindow')) Window.addClass('active');
					if (($('body').data('AeroWindowMaxZIndex')) == null) {
						$('body').data('AeroWindowMaxZIndex', Window.css('z-index'))
					}
					i = $('body').data('AeroWindowMaxZIndex');
					i++;
					Window.css('z-index', i);
					$('body').data('AeroWindowMaxZIndex', Window.css('z-index'))
				}
				if (o.WindowMaximize) {
					$(this).dblclick(function() {
						switch (o.WindowStatus) {
						case 'regular':
							MaximizeWindow();
							break;
						case 'maximized':
							RegularWindow();
							break;
						case 'minimized':
							RegularWindow();
							break;
						default:
							break
						}
					})
				} else {
					$(this).dblclick(function() {
						switch (o.WindowStatus) {
						case 'maximized':
							RegularWindow();
							break;
						case 'minimized':
							RegularWindow();
							break;
						default:
							break
						}
					})
				}
				BTNMin.click(function() {
					FocusWindow(Window);
					MinimizeWindow();
					return false
				});
				BTNMax.click(function() {
					FocusWindow(Window);
					MaximizeWindow();
					return false
				});
				BTNReg.click(function() {
					FocusWindow(Window);
					RegularWindow();
					return false
				});
				BTNClose.click(function() {
					Window.css('display', 'none');
					return (false)
				});
				if (o.WindowDraggable) {
					Window.draggable({
						distance: 3,
						cancel: ".table-mm-content",
						start: function() {
							FocusWindow(Window);
							$(".AeroWindow").find('#iframeHelper').css({
								'display': 'block'
							});
							$(".AeroWindow").removeClass('active');
							$(this).addClass('active');
							$('body').data('AeroWindowMaxZIndex', $(this).css('z-index'))
						},
						drag: function() {
							WindowTop = -1 * $(this).offset().top;
							WindowLeft = -1 * $(this).offset().left;
							$(this).css({
								backgroundPosition: WindowLeft + 'px ' + WindowTop + 'px'
							})
						},
						stop: function() {
							o.WindowPositionTop = Window.css('top');
							o.WindowPositionLeft = Window.css('left');
							$(".AeroWindow").find('#iframeHelper').css({
								'display': 'none'
							})
						}
					})
				}
				Window.click(function() {
					FocusWindow(Window)
				});
				if (o.WindowResizable) {
					Window.resizable({
						minHeight: o.WindowMinHeight + 72,
						minWidth: o.WindowMinWidth,
						alsoResize: WindowContent,
						start: function() {
							WindowContainer.css('visibility', 'visible');
							$(".AeroWindow").find('#iframeHelper').css({
								'display': 'block'
							});
							$(".AeroWindow").removeClass('active');
							Window.addClass('active');
							if (($('body').data('AeroWindowMaxZIndex')) == null) {
								$('body').data('AeroWindowMaxZIndex', Window.css('z-index'))
							}
							i = $('body').data('AeroWindowMaxZIndex');
							i++;
							Window.css('z-index', i);
							$('body').data('AeroWindowMaxZIndex', Window.css('z-index'))
						},
						stop: function() {
							o.WindowWidth = WindowContent.width();
							o.WindowHeight = WindowContent.height();
							$(".AeroWindow").find('#iframeHelper').css({
								'display': 'none'
							})
						}
					})
				}
			})
		}
	})
})(jQuery);
function RequestView(options, obj) {
	var faqdefaults = {
		Title: '',
		Width: 950,
		Height: 550,
		InsideWidth: 920,
		InsideHeight: 700,
		Server: '',
		FileUrl: '',
		FileName: '',
		FileAttribute: '',
		FileSourceUrl: '',
		IsDownFile: false,
		IsDownSource: false,
		showheader: false,
		IsCover: false,
		DocumentID: '*',
		WindowAppID: '',
		WindowHiddenID: '',
		PlatformID: 'faqict',
		Password: '1236',
		Iframe: true,
		Operator: '',
		minue:'0',
		Module: '123'
	};
	var sets = $.extend(faqdefaults, options);
	if (sets.Title == '') {
		sets.Title = sets.FileName
	}
	var objid = $(obj).attr('id');
	var urlkey = sets.FileUrl + "|" + sets.FileName + "|" + sets.FileAttribute + "|" + sets.FileSourceUrl + "|" + sets.IsDownFile + "|" + sets.IsDownSource + "|" + sets.PlatformID + "|" + sets.Module + "|" + sets.showheader + "|" + sets.DocumentID + "|" + sets.Operator + "|" + sets.InsideWidth + "|" + sets.InsideHeight + "|" + sets.IsCover + "|" + sets.minue + "|" + sets.fileid + "|" + sets.supportHtml5;
	var s = document.getElementById("BackSID");
	var theSame = true;
	if (!s) {
		$("#" + sets.WindowHiddenID).html("<input type='hidden' id='BackSID' /><input type='hidden' id='ActiveID' />");
		$("#ActiveID").val(objid)
	} else {
		if ($("#ActiveID").val() == objid) {
			theSame = true
		} else {
			theSame = false;
			$("#ActiveID").val(objid);
			$("#" + sets.WindowAppID).html("")
		}
	}
	if (($("#BackSID").val() == "") || ($("#BackSID").val() == "undefined")) {
		var qsData = {
			'PlatformID': sets.PlatformID,
			'Password': sets.Password
		};
		$.getJSON("http://" + sets.Server + "/RequestConnect.php?jsoncallback=?", qsData,
		function(msg) {
			if (typeof(msg.error) != 'undefined') {
				if (msg.error != '') {
					alert(msg.error)
				} else {
					$("#BackSID").val(msg.msg);
					LoadViews(theSame, sets.WindowAppID, sets.Title, sets.Width, sets.Height, sets.Server, urlkey, sets.Iframe)
				}
			} else {
				alert(msg.error)
			}
		})
	} else {
		LoadViews(theSame, sets.WindowAppID, sets.Title, sets.Width, sets.Height, sets.Server, urlkey, sets.Iframe)
	}
}
function LoadViews(WSame, WindowAppID, WTitle, WWidth, WHeight, WServer, WUrlKey, WIframe) {

		var url = 'http://' + WServer + '/receive.php?Captcha=' + $("#BackSID").val() + '&key=' + encodeURI(WUrlKey);
		var name = WTitle;
		var iWidth = WWidth;
		var iHeight = WHeight;
		var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
		var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
		var Rd = parseInt(Math.random()*100000);
		window.open(url+"&rd="+Rd,"","location=no,menubar=no,scrollbars=no,status=no,titlebar=no,toolbar=no,resizable=no,width=1400,height=800");
}
jQuery.easing['jswing'] = jQuery.easing['swing'];
jQuery.extend(jQuery.easing, {
	def: 'easeOutQuad',
	swing: function(x, t, b, c, d) {
		return jQuery.easing[jQuery.easing.def](x, t, b, c, d)
	},
	easeInQuad: function(x, t, b, c, d) {
		return c * (t /= d) * t + b
	},
	easeOutQuad: function(x, t, b, c, d) {
		return - c * (t /= d) * (t - 2) + b
	},
	easeInOutQuad: function(x, t, b, c, d) {
		if ((t /= d / 2) < 1) return c / 2 * t * t + b;
		return - c / 2 * ((--t) * (t - 2) - 1) + b
	},
	easeInCubic: function(x, t, b, c, d) {
		return c * (t /= d) * t * t + b
	},
	easeOutCubic: function(x, t, b, c, d) {
		return c * ((t = t / d - 1) * t * t + 1) + b
	},
	easeInOutCubic: function(x, t, b, c, d) {
		if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
		return c / 2 * ((t -= 2) * t * t + 2) + b
	},
	easeInQuart: function(x, t, b, c, d) {
		return c * (t /= d) * t * t * t + b
	},
	easeOutQuart: function(x, t, b, c, d) {
		return - c * ((t = t / d - 1) * t * t * t - 1) + b
	},
	easeInOutQuart: function(x, t, b, c, d) {
		if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
		return - c / 2 * ((t -= 2) * t * t * t - 2) + b
	},
	easeInQuint: function(x, t, b, c, d) {
		return c * (t /= d) * t * t * t * t + b
	},
	easeOutQuint: function(x, t, b, c, d) {
		return c * ((t = t / d - 1) * t * t * t * t + 1) + b
	},
	easeInOutQuint: function(x, t, b, c, d) {
		if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
		return c / 2 * ((t -= 2) * t * t * t * t + 2) + b
	},
	easeInSine: function(x, t, b, c, d) {
		return - c * Math.cos(t / d * (Math.PI / 2)) + c + b
	},
	easeOutSine: function(x, t, b, c, d) {
		return c * Math.sin(t / d * (Math.PI / 2)) + b
	},
	easeInOutSine: function(x, t, b, c, d) {
		return - c / 2 * (Math.cos(Math.PI * t / d) - 1) + b
	},
	easeInExpo: function(x, t, b, c, d) {
		return (t == 0) ? b: c * Math.pow(2, 10 * (t / d - 1)) + b
	},
	easeOutExpo: function(x, t, b, c, d) {
		return (t == d) ? b + c: c * ( - Math.pow(2, -10 * t / d) + 1) + b
	},
	easeInOutExpo: function(x, t, b, c, d) {
		if (t == 0) return b;
		if (t == d) return b + c;
		if ((t /= d / 2) < 1) return c / 2 * Math.pow(2, 10 * (t - 1)) + b;
		return c / 2 * ( - Math.pow(2, -10 * --t) + 2) + b
	},
	easeInCirc: function(x, t, b, c, d) {
		return - c * (Math.sqrt(1 - (t /= d) * t) - 1) + b
	},
	easeOutCirc: function(x, t, b, c, d) {
		return c * Math.sqrt(1 - (t = t / d - 1) * t) + b
	},
	easeInOutCirc: function(x, t, b, c, d) {
		if ((t /= d / 2) < 1) return - c / 2 * (Math.sqrt(1 - t * t) - 1) + b;
		return c / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + b
	},
	easeInElastic: function(x, t, b, c, d) {
		var s = 1.70158;
		var p = 0;
		var a = c;
		if (t == 0) return b;
		if ((t /= d) == 1) return b + c;
		if (!p) p = d * .3;
		if (a < Math.abs(c)) {
			a = c;
			var s = p / 4
		} else var s = p / (2 * Math.PI) * Math.asin(c / a);
		return - (a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b
	},
	easeOutElastic: function(x, t, b, c, d) {
		var s = 1.70158;
		var p = 0;
		var a = c;
		if (t == 0) return b;
		if ((t /= d) == 1) return b + c;
		if (!p) p = d * .3;
		if (a < Math.abs(c)) {
			a = c;
			var s = p / 4
		} else var s = p / (2 * Math.PI) * Math.asin(c / a);
		return a * Math.pow(2, -10 * t) * Math.sin((t * d - s) * (2 * Math.PI) / p) + c + b
	},
	easeInOutElastic: function(x, t, b, c, d) {
		var s = 1.70158;
		var p = 0;
		var a = c;
		if (t == 0) return b;
		if ((t /= d / 2) == 2) return b + c;
		if (!p) p = d * (.3 * 1.5);
		if (a < Math.abs(c)) {
			a = c;
			var s = p / 4
		} else var s = p / (2 * Math.PI) * Math.asin(c / a);
		if (t < 1) return - .5 * (a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
		return a * Math.pow(2, -10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p) * .5 + c + b
	},
	easeInBack: function(x, t, b, c, d, s) {
		if (s == undefined) s = 1.70158;
		return c * (t /= d) * t * ((s + 1) * t - s) + b
	},
	easeOutBack: function(x, t, b, c, d, s) {
		if (s == undefined) s = 1.70158;
		return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b
	},
	easeInOutBack: function(x, t, b, c, d, s) {
		if (s == undefined) s = 1.70158;
		if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525)) + 1) * t - s)) + b;
		return c / 2 * ((t -= 2) * t * (((s *= (1.525)) + 1) * t + s) + 2) + b
	},
	easeInBounce: function(x, t, b, c, d) {
		return c - jQuery.easing.easeOutBounce(x, d - t, 0, c, d) + b
	},
	easeOutBounce: function(x, t, b, c, d) {
		if ((t /= d) < (1 / 2.75)) {
			return c * (7.5625 * t * t) + b
		} else if (t < (2 / 2.75)) {
			return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b
		} else if (t < (2.5 / 2.75)) {
			return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b
		} else {
			return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b
		}
	},
	easeInOutBounce: function(x, t, b, c, d) {
		if (t < d / 2) return jQuery.easing.easeInBounce(x, t * 2, 0, c, d) * .5 + b;
		return jQuery.easing.easeOutBounce(x, t * 2 - d, 0, c, d) * .5 + c * .5 + b
	}
});