// 请求的地方设置成true
axios.interceptors.request.use(function (config) {
    $('body').loading({
        loadingWidth: 120,
        title: '',
        name: 'shaomai_loading',
        discription: '',
        direction: 'column',
        type: 'origin',
        // originBg:'#71EA71',
        originDivWidth: 40,
        originDivHeight: 40,
        originWidth: 6,
        originHeight: 6,
        smallLoading: false,
        loadingMaskBg: 'rgba(0,0,0,0.2)'
    });
    return config;
});

// 响应的地方设置成false
axios.interceptors.response.use(function (response) {
    removeLoading('shaomai_loading');
    return response;
});