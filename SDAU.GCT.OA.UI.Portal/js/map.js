var mymap;
var layer;
var layer_label;
var layerraster;
var layerraster_label;

$(document).ready(mapInit); 
//加载地图
function mapInit() {  
		//地图实例化  
    mymap = new NMap("map-canvas");  
		//图层参数设置  
		var lyrOptionswmts = {  
				tileSize:new NXY(256, 256),  
				tileOrigin:new NXY(-180,90),
				maxExtent:new NBounds(-180.0,-90.0, 180.0,90.0), 
				resolutions:[0.010986328125,0.0054931640625,0.00274658203125,0.001373291015625,0.0006866455078125,0.00034332275390625,0.000171661376953125,0.0000858306884765625,0.00004291534423828125,0.000021457672119140625,0.0000107288360595703125,0.00000536441802978515625,0.000002682209014892578125,0.0000013411045074462890625],
				serverResolutions:{'7':0.010986328125,'8':0.0054931640625,'9':0.00274658203125,'10':0.001373291015625,'11':0.0006866455078125,'12':0.00034332275390625,'13':0.000171661376953125,'14':0.0000858306884765625,'15':0.00004291534423828125,'16':0.000021457672119140625,'17':0.0000107288360595703125,'18':0.00000536441802978515625,'19':0.000002682209014892578125,'20':0.0000013411045074462890625}
		};  
		//矢量图层
		//德州图层 18-20配置信息
		var dzlayeroption = {
				format:"image/png",  
				units:"dd",  
				projection:"CGCS2000",  
				layer:"base",  
				style:"Default",  
				serviceMode:'KVP',  
				tileMatrixSet:"TileMatrixSet_0"  
		};
		//省图层 2-17配置信息
		var provinceoption = {
			format:"image/png",  
			units:"dd",  
			projection:"CGCS2000",  
			layer:"0",  
			style:"default",  
			serviceMode:'KVP',  
			tileMatrixSet:"taishannew" 
		};
		
			
		var configopt = [{url:'http://124.128.48.210/tileservice/sdpubmap',z:[7,8,9,10,11,12,13,14,15,16,17],params:provinceoption},{url:'http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZVectorMap/wmts',z:[18,19,20],params:dzlayeroption}];		
		layer = new NExtWMTSLayer("WMTS", "http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZVectorMap/wmts", lyrOptionswmts,configopt); 
		mymap.addLayer(layer); 

		//矢量注记图层
		//德州市注记层配置信息
		var dzoption_label={
			format:"image/png",  
			units:"dd",  
			projection:"CGCS2000",   
			layer:"base",  
			style:"Default",  
			serviceMode:'KVP',  
			tileMatrixSet:"TileMatrixSet_0" 
		};
		
		var configopt_label = [{url:'http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZVectorAnnoMap/wmts',z:[18,19,20],params:dzoption_label}];		
		layer_label = new NExtWMTSLayer("WMTS", "http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZVectorMap/wmts?", lyrOptionswmts,configopt_label);
		layer_label.isBasicLayer  = false;
		mymap.addLayer(layer_label); 
		
		//影像图层
		//德州市影像18-20配置信息
		var dzrasteroption = {
				format:"image/png",  
				units:"dd",  
				projection:"CGCS2000",  
				layer:"rcyxqp",  
				style:"Default",  
				serviceMode:'KVP',  
				tileMatrixSet:"TileMatrixSet_0"  
		};
		//山东省影像 2-17配置信息
		var sdrasteroption = {
			format:"image/jpeg",  
			units:"dd",  
			projection:"CGCS2000",  
			layer:"0",  
			style:"default",  
			serviceMode:'KVP',  
			tileMatrixSet:"tianditu2013" 
		};
		var configrasteropt = [{url:'http://www.sdmap.gov.cn/tileservice/SDRasterPubMap',z:[7,8,9,10,11,12,13,14,15,16,17],params:sdrasteroption},{url:'http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZRasterMap/wmts',z:[18,19,20],params:dzrasteroption}];		
		layerraster = new NExtWMTSLayer("WMTSraster", "http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZRasterMap/wmts", lyrOptionswmts,configrasteropt); 
		layerraster.isBasicLayer = true;
		mymap.addLayer(layerraster); 
 
		//影像注记
		//德州市注记层配置信息
		var dzraster_label={
			format:"image/png",  
			units:"dd",  
			projection:"CGCS2000",   
			layer:"base",  
			style:"Default",  
			serviceMode:'KVP',  
			tileMatrixSet:"TileMatrixSet_0" 
		};
		//山东影像注记
		var sdraster_label={
			format:"image/png",  
			units:"dd",  
			projection:"CGCS2000",   
			layer:"0",  
			style:"default",  
			serviceMode:'KVP',  
			tileMatrixSet:"taishannew" 
		};
		
		var configraster_label = [{url:'http://www.sdmap.gov.cn/tileservice/SDPubRasterNoteMapall',z:[7,8,9,10,11,12,13,14,15,16,17],params:sdraster_label},{url:'http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZRasterAnnoMap/wmts',z:[18,19,20],params:dzraster_label}];		
		layerraster_label = new NExtWMTSLayer("WMTS", "http://www.dzmap.gov.cn/newmap/tianditu/TIANDITU/DZRasterAnnoMap/wmts", lyrOptionswmts,configraster_label);
		layerraster_label.isBasicLayer  = false;
		layerraster_label.visible = false;
		mymap.addLayer(layerraster_label); 
		//将当前地图缩放到指定的中心点和级别
      mymap.moveTo(new NXY(116.342268, 37.16564), 6);  
		 
	mymap.addControl(new NPanZoomBarControl({useZoomBarTag:true}));  
    mymap.addControl(new NPositionControl());
    mymap.addControl(new NScaleControl());  
    mymap.setMode("dragzoom");

    
    $.getJSON("../../TouristPlanning/GetALLTourismPlanning", {}, function (data) {
        console.log(data);
        var gisdata = data.data;
        for (var i = 0; i < data.count; i++) {
            var marker = new NMarker(new NXY(gisdata[i].Longitude, gisdata[i].Latitude), { markerTitle: gisdata[i].JDMingCheng, assignId: gisdata[i].JDBianHao, imgUrl: "../../map/images/marker_red.png" });
            marker.setDialog("<div style ='margin:0px;' > " +
                "<div style='margin:10px 10px; '>" +

                "  <div style='width:200px;height:auto'>规划名称:" + gisdata[i].Name +
                "<br>规划年限:" + gisdata[i].PlanYears +
                "<br>负责人:" + gisdata[i].PlanLeader +
                "<span style='width:169px'></span></div>" +
                "</div>" +
                "&nbsp;&nbsp;<input type='button' name='delete' value ='查看' id ='view' onclick=view(" + gisdata[i].Id + ") />" +
                "&nbsp;&nbsp;<input type='button' name='delete' value ='我要留言' id ='edit' onclick=edit(" + gisdata[i].Id + ") />" +
                "&nbsp;&nbsp;<input type='button' name='delete' value ='收藏' id ='delete' onclick=delete1(" + gisdata[i].Id + ") />" +
                "&nbsp;&nbsp;<input type='button' name='delete' value ='举报' id ='delete' onclick=delete1(" + gisdata[i].Id + ") />" +
                "</div>");
            //标注添加到地图
            mymap.addOverlays(marker);
        }
    });

    $.getJSON("../layui/json/TouristAttractionListMap.json", {}, function (data) {
        console.log(data);
        var gisdata = data.data;
        for (var i = 0; i < data.count; i++) {
            var marker = new NMarker(new NXY(gisdata[i].Longitude, gisdata[i].Latitude), { markerTitle: gisdata[i].Name, assignId: gisdata[i].Id });
            marker.setDialog("<div style ='margin:0px;' > " +
                "<div style='margin:10px 10px; '>" +
                //"<img style='float:left;margin:0px 10px' width='100' height='80' src='" + gisdata[i].Image + "+/>" +
                "<img style='float:left;margin:0px 10px' width='100' height='80' src=" + gisdata[i].Image + ">" +

                "<div style='margin:0px 0px 0px 120px;width:170px;height:auto'>景点名称:" + gisdata[i].Name +
                "<br>景点简介: " + gisdata[i].Introduce + " <span style = 'width:170px' ></span ></div >" +
                "</div>" +
                "<button class='layui-btn layui-btn-xs' style='margin-top: 5px; margin-bottom: 5px'>查看</button>" +
                "<button class='layui-btn layui-btn-xs' style='margin-top: 5px; margin-bottom: 5px'>我要留言</button>&nbsp;" +
                "<button class='layui-btn layui-btn-xs' style='margin-top: 5px; margin-bottom: 5px'>收藏</button>" +
                "</div>");
            //标注添加到地图  
            mymap.addOverlays(marker);
        }
    });
    $("#vec_").click(showVector);
		$("#img_").click(showRaster);
};  
function view(id) {
    $.getJSON("../Admin/ashx/GetlyghInfo.ashx", { id: id }, function (data) {
        $("#GHXMBianHao").text(data.GHXMBianHao);
        $("#GHXMMingCheng").text(data.GHXMMingCheng);
        $("#FuZeRen").text(data.FuZeRen);
        $("#GuiHuaDanWei").text(data.GuiHuaDanWei);
        $("#GuiHuaShiJian").text(ConvertTime(data.GuiHuaShiJian) != "2000-1-1" ? ConvertTime(data.GuiHuaShiJian) : "");
        $("#GuiHuaNianXian").text(data.GuiHuaNianXian == "" ? "" : data.GuiHuaNianXian.split('|')[0] + "——" + data.GuiHuaNianXian.split('|')[1]);
        $("#GuiHuaFanWei").text(data.GuiHuaFanWei);
        $("#GuiHuaMianJi").text(data.GuiHuaMianJi);
        $("#GuiHuaMuBiao").html(data.GuiHuaMuBiao);
        $("#GuiHuaRenWu").html(data.GuiHuaRenWu);
        $("#GHXMJieShao").html(data.GHXMJieShao);
        //动态添加a标签
        var html = '<a href=\"#\" style="font-size:15px;" id="guihuatu_a" onclick=\"ShowGuiHuaTu(\'' + id + '\')\">查看规划图</a>';
        $(html).appendTo($("#guihautudiv"));
    })
    if ($("#centerlist2").is(":hidden")) {
        $("#centerlist2").show("slow");
        dragging("centerlist2");
    }
}
function jdComment(id) {
    $.getJSON("../Admin/ashx/GetlyjdInfo.ashx", { id: id }, function (data) {
        //$("#jinddianjieshao").html(unescape(data.JDJieShao));
        $("#comment").val("@" + data.JDMingCheng + "@    ");
        $("#DeleteFlag").val(id);
        //$("#comment").css("color", "red");
        $("#comment").focus();
    });
    if ($("#hudongjiaoliu").is(":hidden")) {
        $("#hudongjiaoliu").show("slow");
        dragging("hudongjiaoliu");
    }
}

function ghComment(id) {
    $.getJSON("../Admin/ashx/GetlyghInfo.ashx", { id: id }, function (data) {
        $("#comment").val("@" + data.GHXMMingCheng + "@   ");
        $("#DeleteFlag").val(id);
        $("#comment").focus();
    });
    if ($("#hudongjiaoliu").is(":hidden")) {
        $("#hudongjiaoliu").show("slow");
    }
}

function showRaster()
{
	$("#vec_").removeClass("active");
	$("#img_").addClass("active");
	mymap.setBasicLayer(layerraster);
	layer_label.visible = false;
	layerraster_label.visible = true;
}
function showVector()
{
	$("#img_").removeClass("active");
	$("#vec_").addClass("active");
	mymap.setBasicLayer(layer);
	layer_label.visible = true;
	layerraster_label.visible = false;
}
//===========================listbegin================

function gkxxlist(){
	if ($("#bottomlist").is(":hidden")) {
        $("#bottomlist").show("slow");
        dragging("bottomlist");
        $("#markerMenu").css("display", "none");
	}
}

function closebottomlist(){
    $("#bottomlist").hide("slow");
    $("#markerMenu").css("display", "block");
}

function lyghlist() {


    if ($("#leftlist").is(":hidden")) {
        $("#leftlist").show("slow");
        dragging("leftlist");
    }
}

function closeleftlist(){
	$("#leftlist").hide("slow");
}
function hdjllist() {
    if ($("#hudongjiaoliu").is(":hidden")) {
        $("#hudongjiaoliu").show("slow");
        dragging("hudongjiaoliu");
    }
}

function closehudongjiaoliu() {
    $("#hudongjiaoliu").hide("slow");
}

function gkxx_view(id) {
    $.getJSON("../Admin/ashx/GetgkxxInfo.ashx", { id: id }, function (data) {
        $("#Infotitle").text(data.BiaoTi);
        $("#zuozhe").text(data.ZuoZe);
        $("#LeiXing").text(data.LeiXing);
        $("#fabushijian").text(ConvertTime(data.FaBuShiJian));
        $("#neirong").html(unescape(data.NeiRong));
        //$("title").text(data.BiaoTi);
    })
    if ($("#centerlist").is(":hidden")) {
        $("#centerlist").show("slow");
        dragging("centerlist");
    }
}

function lygh_view(id) {
    $.getJSON("../Admin/ashx/GetlyghInfo.ashx", { id: id }, function (data) {
        $("#GHXMBianHao").text(data.GHXMBianHao);
        $("#GHXMMingCheng").text(data.GHXMMingCheng);
        $("#FuZeRen").text(data.FuZeRen);
        $("#GuiHuaDanWei").text(data.GuiHuaDanWei);
        $("#GuiHuaShiJian").text(ConvertTime(data.GuiHuaShiJian) != "2000-1-1" ? ConvertTime(data.GuiHuaShiJian ): "");
        $("#GuiHuaNianXian").text(data.GuiHuaNianXian == "" ? "" : data.GuiHuaNianXian.split('|')[0] + "——" + data.GuiHuaNianXian.split('|')[1]);
        $("#GuiHuaFanWei").text(data.GuiHuaFanWei);
        $("#GuiHuaMianJi").text(data.GuiHuaMianJi);
        $("#GuiHuaMuBiao").html(data.GuiHuaMuBiao);
        $("#GuiHuaRenWu").html(data.GuiHuaRenWu);
        $("#GHXMJieShao").html(data.GHXMJieShao);
        //动态添加a标签
        var html = '<a href=\"#\" style="font-size:15px;" id="guihuatu_a" onclick=\"ShowGuiHuaTu(\'' + id + '\')\">查看规划图</a>';
        $(html).appendTo($("#guihautudiv")); 
    })
    if ($("#centerlist2").is(":hidden")) {
        $("#centerlist2").show("slow");
        dragging("centerlist2");
    }
}

function lyjd_view(id) {
    $.getJSON("../Admin/ashx/GetlyjdInfo.ashx", { id: id }, function (data) {
        $("#jinddianjieshao").html(unescape(data.JDJieShao));

    });

    if ($("#centerlist4").is(":hidden")) {
        $("#centerlist4").show("slow");
        dragging("centerlist4");
    }
}
//公开信息详情页Div
function closecenterlist() {
    $("#centerlist").hide("slow");
}
//规划详情页div
function closecenterlist2() {
    $("#centerlist2").hide("slow");
    $("#guihautudiv").children().remove();
}
//规划图div
function closecenterlist3() {
    $("#centerlist3").hide("slow");
}
function closecenterlist4() {
    $("#centerlist4").hide("slow");
}


function ShowGuiHuaTu(id) {
    $.getJSON("../Admin/ashx/GetlyghInfo.ashx", { id: id }, function (data) {
                var html = data.GuiHuaTu;
        var text = unescape(html);
        $("#guihuatu").html(text);
    })
    if ($("#centerlist3").is(":hidden")) {
        $("#centerlist3").show("slow");
        dragging("centerlist3");

    }
}














////===========================listend================
//========================common=========
function index() {
    window.location.reload();
}
function gotoHomePage() {
    window.location.reload();
}
function formatDate(dt) {
    var year = dt.getFullYear();
    var month = dt.getMonth() + 1;
    var date = dt.getDate();
    return year + "-" + month + "-" + date;
}
function ConvertTime(time) {
    var t = time.slice(6, 19)
    var NewDtime = new Date(parseInt(t));
    return formatDate(NewDtime);
}