mergeInto(LibraryManager.library, {








  getUserName: function () {

      var startStr= decodeURIComponent(document.cookie);
      var parts = startStr.split("user_name=");
      var returnStr = "";
      if (parts.length === 2){
          returnStr =  parts.pop().split(';').shift();
          }
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    console.log("Testing Javascript in game");
    return buffer;

  },
  setCookie: function () {
   var d = new Date();
   d.setTime(d.getTime() + (1*24*60*60*1000));
   var expires = "expires="+ d.toUTCString();
   document.cookie = "user_name" + "=" + "Mr.Man" + ";" + expires + ";path=/";
   console.log('set cookie='+document.cookie);
}
});