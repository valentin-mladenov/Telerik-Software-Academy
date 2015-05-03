(function() {
    $(document).ready(function () {
        $("#submit").click(function () {
            var username = $('#username').val();
            var password = $('#password').val();
            var email = $('#email').val();

            if (username === "" || password === "" || email === "") {
                $("#result").html("Username/Password are mandatory fields -- Please Enter.");
            } else {
                $.ajax({
                    type: "POST",
                    url: "parts/Ajax.php",
                    data: "username=" + username + "&password=" + password + "&email=" + email,
                    cache: false,
                    success: function(result) {
                    $('#result').html(result[0]);
                }
                });
                return false;
            }
        });
    });
})();