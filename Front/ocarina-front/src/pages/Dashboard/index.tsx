import './style.css';
import Fogo from '../../assets/fogo.png'
import FogoApagado from '../../assets/fogo-apagado.png'
import Star from '../../assets/star.png'
import Calendario from '../../assets/calendario.png'
import Haltere from '../../assets/haltere.png'
import Plus from '../../assets/PLUS.png'
import Olho from '../../assets/olho.png'
import OlhoFechado from '../../assets/fechar-o-olho.png'
import { useEffect } from 'react';
import api from '../../services/Api';
import ReactDOM from 'react-dom';
import moment from 'moment';
import $ from 'jquery';
import 'animate.css';

function Dashboard() {

    var exrcicios: any[] = []
    useEffect(() => {
        BuscarExercicios();
        $("#olhoA").on('click', function(){
            console.log("teste");
            $("#olhoA").hide();
            $(".container-top").hide();
            $("#olhoF").show();
            $('.esconder').css({ margin:"13em" });
            $( ".esconder" ).addClass( "animate__zoomIn" );
    
        });
    
        $("#olhoF").on('click', function(){
            $("#olhoF").hide();
            $(".container-top").show();
            $("#olhoA").show();
            $( ".esconder" ).removeClass( "animate__zoomIn" );
            $('.esconder').css({margin:"0em" });
    
        });
    }, [])

    function BuscarExercicios() {
        debugger;
        let div = document.getElementById("area-exercicio");
        api.get("Exercise/ListaExercise")
            .then(res => {

                res.data.map(((exercicio: any) => {
                    exrcicios.push(exercicio)
                }))

                ReactDOM.render(ModeloExercicio(res.data), div)

            }).catch((err) => {
                console.error("ops! ocorreu um erro : " + err);
            });
    }

    function MudarPagina() {
        window.location.href = "/cadastro"
        
    }

    

    const ModeloExercicio = (e: any) => {

        return (
            <div>
                {e.map((exercicio: any) => (
                    <div className='container-tasks '>
                        <div className='tasks'>
                            <img className="icon-task" src={Haltere} />
                            <p className='text-task'>{exercicio.name}</p>
                        </div>

                        <div className='tasks'>
                            <img className="icon-task" src={Calendario} />
                            <p className='text-task'>{moment(exercicio.finished).format('MM/DD/YYYY')}</p>
                        </div>

                        <div className='tasks'>
                            <img className="icon-task" src={Fogo} />
                            <p className='text-task'>{exercicio.caloriesBurned} <span className='span-task'>kcal</span></p>
                        </div>

                    </div>
                ))}
            </div>
        );
    }


    return (
        <>
            <div className="page">
                    <div className="logo">
                        <img className='animate__animated animate__backInDown'  src={Fogo}  />
                    </div>

                <div className="volta">
                    <div className="left">
                        <div className="containter-meta">
                            <img className="star" src={Star} />
                            <p className='goals-kcal'>Meta de calorias do dia:</p>
                            <p className='goals-kcal'>300 <span>kcal</span></p>
                        </div>

                        <div className="container-exercicios animate__animated animate__zoomIn">
                            <h1 className='title-exercise'>Exercícios</h1>
                            <div id="area-exercicio">

                            </div>
                            
                            <div className='container-plus' onClick={MudarPagina} >
                                <img className="icon-task" src={Plus} />
                                <p className='text-task'>ADICIONAR EXERCÍCIO</p>
                            </div>
                        </div>
                    </div>
                    <div className="right">
                        <div className="esconder animate__animated">
                            <img id='olhoA' src={Olho} alt="" height={"50"} />
                            <img id='olhoF' src={OlhoFechado} alt="" height={"50"} hidden />
                        </div>
                        <div className="container-top animate__animated animate__zoomIn">
                            <h1 className='title-calories'>Top calorias no mês</h1>
                            <p className='p-kcal'>32.050 <span className='span-kcal'>/cal</span></p>
                            <h1 className='title-calories'>Dias consecutivos</h1>
                            <div className="grid-days">
                                <div className='day'>
                                    <p className='text-day'>SEG</p>
                                    <img className="fogo" src={Fogo} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>TER</p>
                                    <img className="fogo" src={Fogo} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>QUA</p>
                                    <img className="fogo" src={Fogo} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>QUI</p>
                                    <img className="fogo" src={Fogo} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>SEX</p>
                                    <img className="fogo-apagado" src={FogoApagado} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>SAB</p>
                                    <img className="fogo-apagado" src={FogoApagado} />
                                </div>
                                <div className='day'>
                                    <p className='text-day'>DOM</p>
                                    <img className="fogo-apagado" src={FogoApagado} />
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </>
    )



}

export default Dashboard;