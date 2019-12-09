
document.getElementById('btnPlay').addEventListener('click', function () {
    let name1;
    let movement1;
    let name2;
    let movement2;
    const tournament = [];
    jQuery('#tblTournament tbody > tr').each(function () {

        name1 = jQuery(this).find('td').eq(0).text();
        movement1 = jQuery(this).find('td').eq(1).text();

        name2 = jQuery(this).find('td').eq(3).text();
        movement2 = jQuery(this).find('td').eq(4).text();

        const Player1 = {
            Name: name1,
            Movement: movement1
        };

        const Player2 = {
            Name: name2,
            Movement: movement2
        };


        const battle = {
            Player1: Player1,
            Player2: Player2
        };

        tournament.push(battle);
    });


    fetch('battletournament', {
        method: 'post',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tournament)
    }).then(res => res.json())
        .then(res => {

            if (res != null) {

                let WinnerMsg = res.Name + "<br/>";
                WinnerMsg += res.Movement == "P" ? "Papel" : res.Movement == "R" ? "Pedra" : "Tesoura";
                toastr['success'](WinnerMsg, "Vencedor");

            }
            else
                toastr['error']("AÇÃO INVÁLIDA", 'ERRO');
        });
});

document.getElementById('btnAdd').addEventListener('click', function () {

    let name1 = document.getElementById('txtname1').value;
    let rock1 = document.getElementById('rock1');
    let paper1 = document.getElementById('paper1');
    let scissors1 = document.getElementById('scissors1');

    let name2 = document.getElementById('txtname2').value;
    let rock2 = document.getElementById('rock2');
    let paper2 = document.getElementById('paper2');
    let scissors2 = document.getElementById('scissors2');

    let movement1;

    if (rock1.checked)
        movement1 = "R";
    if (paper1.checked)
        movement1 = "P";
    if (scissors1.checked)
        movement1 = "S";


    if (rock2.checked)
        movement2 = "R";
    if (paper2.checked)
        movement2 = "P";
    if (scissors2.checked)
        movement2 = "S";

    let msg = "";

    //Verificacao se existe os 2 jogadores
    if (name1 == null || name2 == "" || name2 == null || name2 == "") {
        msg += "Por favor insira 2 jogadores<br/>";
    }

    //Verifica se as ações sao validas dos dois jogadores
    if ((movement1 != "P" && movement1 != "S" && movement1 != "R") || (movement2 != "P" && movement2 != "S" && movement2 != "R")) {
        msg += "Insira os movimentos corretos! <br/>";
    }

    if (msg != null && msg != "") {
        toastr['error'](erro, "ERRO");
    }
    else {
        let tr = `<tr>
                    <td>${name1}</td>
                    <td>${movement1}</td>
                    <td>X</td>
                    <td >${name2}</td>
                    <td >${movement2}</td>
                </tr>`;

        jQuery('#tblTournament > tbody').append(tr);

        document.getElementById("txtname1").value = "";
        document.getElementById("txtname2").value = "";
    }
});

