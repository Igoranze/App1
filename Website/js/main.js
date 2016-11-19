$('.render').on('click', function () {
    var pizzas = [];
    $('img').each(function () {
        console.log(this.alt);
        pizzas.push(getAverageRGB(this));
    });

    console.log(pizzas); // returns array with arrays for every image with RGB values & title.
})


/*
* Logic which compares the me image to all others should be here
*/

function getAverageRGB(imgEl) {
    $(imgEl).css('border', '33px solid rgb(' + 0 + ',' + 0 + ',' + 0 + ')');
    var
        pixRate = 10, // only visit every 10 pixels
        defRGB = {r:0, g:0, b:0}, // for non-supporting envs
        canvas = document.createElement('canvas'),
        context = canvas.getContext && canvas.getContext('2d'),
        data, width, height,
        i = -4,
        length,
        rgb = {r:0, g:0, b:0, title: $(imgEl).attr('src').split('.png').shift()},
        count = 0;

    if (!context) {
        console.log('NO CONTEXT!!!');
        return defRGB;
    }

    height = canvas.height = imgEl.naturalHeight || imgEl.offsetHeight || imgEl.height;
    width = canvas.width = imgEl.naturalWidth || imgEl.offsetWidth || imgEl.width;
    
    context.drawImage(imgEl, 0, 0);

    try {
        data = context.getImageData(0, 0, width, height);
    } catch (e) {
        console.log('ERROR:' + e);
        return defRGB;
    }

    length = data.data.length;
    while ( (i += pixRate * 4) < length ) {
        ++count;
        rgb.r += data.data[i];
        rgb.g += data.data[i+1];
        rgb.b += data.data[i+2];
    }

    rgb.r = ~~(rgb.r/count);
    rgb.g = ~~(rgb.g/count);
    rgb.b = ~~(rgb.b/count);

    console.log('r:' + rgb.r + ' g:' + rgb.g + ' b:' + rgb.b );
    $(imgEl).css('border', '33px solid rgb(' + rgb.r.toString() + ',' + rgb.g.toString() + ',' + rgb.b.toString() + ')');

    return rgb;
}
