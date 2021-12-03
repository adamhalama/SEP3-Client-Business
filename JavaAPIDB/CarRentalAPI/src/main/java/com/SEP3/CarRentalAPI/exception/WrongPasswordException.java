package com.SEP3.CarRentalAPI.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(value = HttpStatus.UNAUTHORIZED)
public class WrongPasswordException extends Exception
{
    private static final long serialVersionUID = 1L;

    public WrongPasswordException(String message){
        super(message);
    }
}
