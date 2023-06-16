import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import api from '../../services/Api';
import $ from 'jquery';
import './style.css';
import jwt from 'jwt-decode'
const LOGIN_URL = "Auth/Login";
function Login() {
    const navigate = useNavigate();
    const HandleClick = async () => {
        var email = $("#email").val();
        var password = $("#senha").val();
        var name = "gustavo";
        var caloriesDay = "300";
        debugger;

        var data =
        {
            name,
            email,
            password,
            caloriesDay
        }
        api.post(LOGIN_URL,
            data
        ).then(res => {
            if (res.status == 200) {
                var token = res.data.token;
                // var decoded = jwtDecode(token);
                var role = res.data.role;

                // localStorage.setItem('fastFlex-token', res.data.token);
                navigate("/dashboard");

            } else {
                localStorage.clear();
                alert("Senha ou email incorretos!")
            }
        });
    }

    return (
        <>
            <div className="pageL">
                <form method="POST" className="formLogin">
                    <h1>Login</h1>
                    <p>Digite os seus dados de acesso no campo abaixo.</p>
                    <label >E-mail</label>
                    <input id='email' type="email" placeholder="Digite seu e-mail" />
                    <label >Senha</label>
                    <input id='senha' type="password" placeholder="Digite seu e-mail" />
                    <a href="/">Esqueci minha senha</a>
                    <button onClick={HandleClick}>Entrar</button>
                </form>
            </div>
        </>
    );
}

export default Login;