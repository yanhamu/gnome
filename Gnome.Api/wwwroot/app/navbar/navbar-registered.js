const nr = Vue.component('navbar-registered', {
    methods: {
        logout: function () {
            store.setToken(null);
        },
    },
    template: `<nav class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <router-link class="navbar-brand" to="/home">gnome</router-link>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <router-link to="/accounts">accounts</router-link>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                        reports <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>
                            <router-link to="/report-overview">reports</router-link>
                        </li>
                        <li role="separator" class="divider"></li>
                        <li>
                            <router-link to="/report-wizard">config-reports</router-link>
                        </li>
                        <li>
                            <router-link to="/configuration">config-query</router-link>
                        </li>
                        <li>
                            <router-link to="/expression-builder-wizard">config-expressions</router-link>
                        </li>
                    </ul>
                </li>
                <li>
                    <router-link to="/categories">categories</router-link>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li>
                    <a v-on:click="logout" >log out</a>
                </li>
            </ul>
        </div>
    </div>
</nav>`
})