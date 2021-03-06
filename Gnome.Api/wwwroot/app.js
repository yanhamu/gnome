const routes = [
    { path: '/accounts/:id/transactions', component: TransactionManager, props: true },
    { path: '/accounts/:id', component: AccountDetail, props: true },
    { path: '/accounts', component: Accounts },
    { path: '/categories', component: CategoryManager },
    { path: '/home', component: Home },
    { path: '/configuration', component: QueryWizard },
    { path: '/expressions', component: ExpressionList },
    { path: '/expression-builder-wizard', component: ExpressionBuilderWizard },
    { path: '/report-wizard', component: ReportWizard },
    { path: '/report-overview', component: ReportsOverview },
    { path: '/report-view/:id', name: 'report-view', component: ReportView, props: true },
    { path: '*', redirect: '/home' }]

const router = new VueRouter({ routes })

Vue.http.options.root = 'http://localhost:9020/api';

Vue.http.interceptors.push(function (request, next) {
    var token = store.getToken();
    if (token != null) {
        request.headers.set('Authorization', store.getToken());
    }
    next();
});

// request logging interceptor
Vue.http.interceptors.push(function (request, next) {
    next(function (res) {
        console.log(res);
    });
});

Vue.filter('formatDate', function (value) {
    if (value)
        return moment(String(value)).format('YYYY-MM-DD');
});

Vue.filter('yearMonth', function (value) {
    if (value)
        return moment(String(value)).format('YYYY/MM');
});

const app = new Vue({
    data: {
        state: store.state
    },
    router
}).$mount('#app');