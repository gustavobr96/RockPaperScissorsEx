document.addEventListener("DOMContentLoaded", function () {
   // document.getElementById("pedra").innerHTML = "";
});

document.getElementById("btnBattle").addEventListener("click", function () {

    var name1 = document.getElementById("txtname1").value;
    var paper1 = document.getElementById("paper1");
    var rock1 = document.getElementById("rock1");
    var scissors1 = document.getElementById("scissors1");

    var movement1;

    if (paper1.checked)
        movement1 = 'P';
    if (rock1.checked)
        movement1 = 'R';
    if (scissors1.checked)
        movement1 = 'S';


    var name2 = document.getElementById("txtname2").value;
    var paper2 = document.getElementById("paper2");
    var rock2 = document.getElementById("rock2");
    var scissors2 = document.getElementById("scissors2");

    var movement2;

    if (paper2.checked)
        movement2 = 'P';
    if (rock2.checked)
        movement2 = 'R';
    if (scissors2.checked)
        movement2 = 'S';
   
    let msg = "";
    
    if (name1 == null || name2 == "" || name2 == null || name2 == "") {
        let val = $("#ValWrong").text();

        val = parseInt(val) + 1;

        document.getElementById("ValWrong").innerHTML = val;

        msg += "Informe o nome dos 2 jogadores!<br/>";
    }


    if ((movement1 ==null) || (movement2 == null)) {
        let valno = $("#valNo").text();

        valno = parseInt(valno) + 1;

        document.getElementById("valNo").innerHTML = valno;

        msg += "O movimento dos dois devem ser selecionados!<br/>";
    }

    if (msg != null && msg != "") {
        toastr['error'](msg);
    } else {


        let Player1 = {
            Name: name1,
            Movement: movement1
        };

        let Player2 = {
            Name: name2,
            Movement: movement2
        };

        const battle = {
            Player1: Player1,
            Player2: Player2
        };



        fetch('battle', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(battle)
        }).then(res => res.json())
            .then(res => {

                if (res != null) {

                    let msg = res.Name + "<br/>";
                    msg += res.Movement == "P" ? "Papel" : res.Movement == "R" ? "Pedra" : "Tesoura";
                    toastr['success'](msg, "Vencedor");

                }
                else
                    toastr['error']("AÇÃO INVÁLIDA", 'ERRO');
            });

    }



   

});