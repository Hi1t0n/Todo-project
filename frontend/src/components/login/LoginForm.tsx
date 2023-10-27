import React, { useState } from "react";
import "./css/LoginForm.css";

export const LoginForm = () => {
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");

    return (
        <div className='container'>
            <div className='rectangle'>
                <div>
                    <input
                        className='login-input'
                        placeholder={"Логин"}
                        value={login}
                        onChange={(e) => setLogin(e.target.value)}
                    />
                </div>

                <div>
                    <input
                        className='password-input'
                        type='password'
                        placeholder={"Пароль"}
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>

                <div>
                    <button>Войти</button> <button>Еще не зарегистрированны?</button>
                </div>

            </div>
        </div>
    );
}

export default LoginForm;