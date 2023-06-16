import './style.css';
import Fogo from '../../assets/fogo.png'
import FogoApagado from '../../assets/fogo-apagado.png'
import Star from '../../assets/star.png'
import Calendario from '../../assets/calendario.png'
import Haltere from '../../assets/haltere.png'
import Plus from '../../assets/PLUS.png'

function Dashboard() {
    return (
        <>
            <div className="page">

                <div className="left">
                    <div className="containter-meta">
                        <img className="star" src={Star} />
                        <p className='goals-kcal'>Meta de calorias do dia:</p>
                        <p className='goals-kcal'>300 <span>kcal</span></p>
                    </div>

                    <div className="container-exercicios">
                        <h1 className='title-exercise'>Exercícios</h1>

                        <div className='container-tasks'>
                            <div className='tasks'>
                                <img className="icon-task" src={Haltere} />
                                <p className='text-task'>Correr</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Calendario} />
                                <p className='text-task'>Finalizado</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Fogo} />
                                <p className='text-task'>3050 <span className='span-task'>kcal</span></p>
                            </div>

                        </div>
                        <div className='container-tasks'>
                            <div className='tasks'>
                                <img className="icon-task" src={Haltere} />
                                <p className='text-task'>Correr</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Calendario} />
                                <p className='text-task'>Finalizado</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Fogo} />
                                <p className='text-task'>3050 <span className='span-task'>kcal</span></p>
                            </div>

                        </div>
                        <div className='container-tasks'>
                            <div className='tasks'>
                                <img className="icon-task" src={Haltere} />
                                <p className='text-task'>Correr</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Calendario} />
                                <p className='text-task'>Finalizado</p>
                            </div>

                            <div className='tasks'>
                                <img className="icon-task" src={Fogo} />
                                <p className='text-task'>3050 <span className='span-task'>kcal</span></p>
                            </div>

                        </div>
                        <div className='container-plus'>

                            <img className="icon-task" src={Plus} />
                            <p className='text-task'>ADICIONAR EXERCÍCIO</p>


                        </div>


                    </div>

                </div>
                <div className="right">
                    <div className="container-top">
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
        </>
    )



}

export default Dashboard;