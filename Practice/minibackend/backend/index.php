<?php

switch ($request) {
    case "customer":
        require_once __DIR__. '/routes/customer';
        break;

    case "cashier":
        require_once __DIR__ . '/routes/cashier';
        break;
        
    


}


?>