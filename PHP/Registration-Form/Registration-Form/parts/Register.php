<?php
require 'Header.php';

require 'Ajax.php';

echo '<form method="post">
    <div>
        Username:<input type="text" id="username" name="reguser" placeholder="username" />
    </div>
    <div>
        Password: <input type="password" id="password" name="regpass" placeholder="password" />
    </div>
    <div>
        E-mail: <input type="email" id="email" name="regEmail" placeholder="E-Mail" />
    </div>
    <input type="submit" id="submit" value="Register" />
</form>
<div id="result"></div>';

require 'Footer.php';

