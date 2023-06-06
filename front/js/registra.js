// pegar a informaçao dos inputs, ou seja, da tela e levar para o servidor.
function fazPost(url, body) {
    console.log("corpo para o servidor", body)

    //criando o request 
    let request = new XMLHttpRequest()

    //setando o request o tipo dele.
    request.open("POST", url, true)

    //definimos que aqui é o arquivo json que irá ir para o servidor
    request.setRequestHeader("Content-type", "application/json")

    //enviando o json
    request.send(JSON.stringify(body))

    //funcao para entender a volta dos dados
    request.onload = function () {
        var retornoStatus = request.status
        console.log(request.status, 'Retorno do Staus',)
        //setando o retorno da api    
        if (retornoStatus == 200) {
            location.href = '../html/dash.html'
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Erro!',
                text: 'Email ou senha invalidos! Tente novamente.'
              })
        }
    }

    //comando que faz a chamada da informaçao para ver o que retornou para o usuario casao retorne.
    return request.responseText
}

function functioncadastrafuncionario() {
    //event preventdefault, ele faz coom que a pagina nao carregue.
    event.preventDefault()
    // url para colocar o endpoint;.
    // gerar um endpoint novo toda vez que for fazer a conexão.
    let url = "http://localhost:5257/api/Auth/nova-conta"

    // pegando o elemento do html e o .value pega o valor do que o usuario digitou.    
    let usuario = document.getElementById("usuario").value
    let senha = document.getElementById("senha").value
    let password = document.getElementById("confirmPassword").value
    console.log(usuario)
    console.log(senha)
    console.log(password)
    // transformando o dado do html para levar para o servidor

    // o  que estiver dentro de "", deve ser definido igual ao parametro que esta no servidor.
    body = {
        "email": usuario,
        "password": senha,
        "confirmPassword": password
    }

    fazPost(url, body)
}



