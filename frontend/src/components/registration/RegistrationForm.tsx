import React, {ChangeEvent, useState} from "react";
import InputMask from 'react-input-mask';
import './css/RegistartionForm.css';
export const RegistrationForm = () => {
    const [login,setLogin] = useState("");
    const [password,setPassword] = useState("");
    const [confirmedPassword,setConfirmedPassword] = useState("");
    const [nickname,setNickname] = useState("");
    const [email,setEmail] = useState("");
    const [phoneNumber,setPhoneNumber]=useState("");

    const handlePhoneNumberChange = (e:
        ChangeEvent<HTMLInputElement>) =>{
        setPhoneNumber(e.target.value)
    }

    return(
        <div id='container'>
            <div id='rectangle'>
                <div className='container'>
                    <div>
                        <input
                            id = 'login-input'
                            placeholder={'Логин'}
                            value={login}
                            onChange={(e)=>setLogin(e.target.value)}
                        />
                    </div>
                    <div>
                        <input
                            id = 'nickname-input'
                            placeholder={'Ник'}
                            value={nickname}
                            onChange={(e)=>setNickname(e.target.value)}
                        />
                    </div>

                    <div>
                        <input
                            id='email-input'
                            type='email'
                            placeholder={'Эл.Почта'}
                            value={email}
                            onChange={(e)=>setEmail(e.target.value)}
                        />
                    </div>
                    <div>
                        <InputMask
                            type='tel'
                            id='phonenumber-input'
                            placeholder={'Номер'}
                            value={phoneNumber}
                            onChange={handlePhoneNumberChange}
                            mask="+7 (999) 999-99-99" // Установите нужную маску для номера телефона
                        />

                    </div>

                    <div>
                        <input
                            type='password'
                            id='password-input'
                            placeholder={'Пароль'}
                            value={password}
                            onChange={(e)=>setPassword(e.target.value)}
                        />
                    </div>
                    <div>
                        <input
                            type='password'
                            id='confirmed-password-input'
                            placeholder={'Подтвердите пароль'}
                            value={confirmedPassword}
                            onChange={(e)=>setConfirmedPassword(e.target.value)}
                        />
                    </div>
                    <div>
                        <button id='registration-button'>Зарегистрироваться</button>
                        <button id='loginPage-button'>Уже зарегистрированны?</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default RegistrationForm;