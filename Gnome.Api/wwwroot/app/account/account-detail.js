const AccountDetail = Vue.component('account-detail', {
    props: ['id'],
    created: function () {
        var options = { headers: { Authorization: store.getToken() } };
        this.$http.get('http://localhost:9020/api/accounts/' + this.id, options)
            .then(res => {
                this.account = res.body.result;
            }, res => {
                console.log(res);
            });
    },
    data: function () {
        return { account: { id: null, name: null } }
    },
    template: `
<div class="container-fluid">
    <h3>account settings</h3>
    <form method='post' action="/account/settings/@Model.Id">
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">Name</label>
            <div class="col-sm-10">
                <input type="text" v-model="account.name" class="form-control" />
            </div>
        </div>
        <div class="form-group row">
            <label for="token" class="col-sm-2 col-form-label">Token</label>
            <div class="col-sm-10">
                <input type="text" v-model="account.token" class="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-10 col-sm-2">
                <input type="submit" value="save" class="btn btn-primary btn-block" />
            </div>
        </div>
    </form>
    <div class="row">
        <div class="col-sm-2"></div>
    </div>
    <form method='post' action="/account/remove/@Model.Id">
        <div class="row">
            <div class="col-sm-offset-10 col-sm-2">
                <input type="submit" value="delete" class="btn btn-danger btn-block" />
            </div>
        </div>
    </form>
</div>
`
})