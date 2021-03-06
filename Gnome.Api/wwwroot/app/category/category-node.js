﻿const CategoryNode = Vue.component('category-node', {
    props: ['node'],
    methods: {
        selectNode: function () {
            this.$emit('node-selected', this.node);
        },
        nodeSelected: function (node) {
            this.$emit('node-selected', node);
        }
    },
    template: `
    <div>
    <li v-on:click="selectNode">
        <span>{{ node['name'] }}</span>
        <span class="badge" v-bind:style="{ backgroundColor : node['color'] }">&nbsp;</span>
    </li>
    <ul v-if="node.hasChildren">
        <category-node v-bind:node="node" v-for="node in node.children" :key="node.id" v-on:node-selected="nodeSelected"></category-node>
    </ul>
    </div>`
});