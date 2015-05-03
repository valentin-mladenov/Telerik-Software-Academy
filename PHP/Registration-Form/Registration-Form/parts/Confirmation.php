<?php

$subject = "email confirmation";
$message = "This is a confirmation Email.";

mail($regEmail, $subject, $message);  