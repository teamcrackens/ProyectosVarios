import * as React from 'react'
import Button from 'src/componentes/Button'
import Card from 'src/componentes/Card'
import ProfileImg from 'src/componentes/ProfileImg'


const style = {
    cardPost: {
        width: '100%',
    },
    container:{
        padding: '15px',
    },
    row: {
        display: 'flex',
        justifyContent: 'space-between',
        marginBottom: '10px',
    }
}

export default class Profile extends React.Component{
    public render(){
        return (
            <div style={style.container}>
                <div style={style.row}>
                    <ProfileImg />
                    <Button>Agregar</Button>
                </div>
                <div style={style.row}>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                </div>
                <div style={style.row}>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                </div>
                <div style={style.row}>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                    <Card><img src='http://placekitten.com/200/200'/></Card>
                </div>
            </div>
            
        )
    }
}